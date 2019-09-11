using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace FastEntregasWeb.Controllers
{
    [Authorize]
    public class EntregaController : Controller
    {
        private readonly IGerenciadorEntrega gerenciadorEntrega;
        private readonly IGerenciadorUsuario gerenciadorUsuario;
        private readonly IGerenciadorFormaPagamento gerenciadorFormaPagamento;
        private readonly IGerenciadorFormaPagamentoHasEntrega gerenciadorPagamento;

        public EntregaController(IGerenciadorEntrega _gerenciadorEntrega, IGerenciadorUsuario _gerenciadorUsuario, IGerenciadorFormaPagamento _gerenciadorFormaPagamento, IGerenciadorFormaPagamentoHasEntrega _gerenciadorPagamento)
        {
            gerenciadorEntrega = _gerenciadorEntrega;
            gerenciadorUsuario = _gerenciadorUsuario;
            gerenciadorFormaPagamento = _gerenciadorFormaPagamento;
            gerenciadorPagamento = _gerenciadorPagamento;
        }

        // GET: Entrega
        public ActionResult Index()
        {    
            string userName = User.Identity.Name;
            var usuario = gerenciadorUsuario.ObterPorUserName(userName);
            if (usuario != null)
            {                
                return View(gerenciadorEntrega.ObterTodos().Where(entrega=> entrega.CodUsuarioCliente.Equals(usuario.CodUsuario)));
            }
            return View();
        }

        // GET: Entrega/Details/5
        public ActionResult Details(int id)
        {
            Entrega entrega = gerenciadorEntrega.Obter(id);
            return View(entrega);
        }

        // GET: Entrega/Create
        public ActionResult Create()
        {
            string userName = User.Identity.Name;
            var usuario = gerenciadorUsuario.ObterPorUserName(userName);
            if (usuario != null)
            {
                ViewBag.codUsuario = usuario.CodUsuario;
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Entrega/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EntregaModel entregaModel)
        {
            Entrega entrega = Atribuir(entregaModel);
            int codFormaPagamento = gerenciadorFormaPagamento.ObterPorDescricao(entregaModel.FormaPagamento).CodFormaPagamento;
            FormaspagamentoHasEntrega pagamento = new FormaspagamentoHasEntrega();
            pagamento.CodFormaPagamento = codFormaPagamento;
            pagamento.Valor = entrega.Valor;
            if (ModelState.IsValid)
            {
                
                int codEntrega = gerenciadorEntrega.Inserir(entrega);
                pagamento.CodEntrega = codEntrega;
                gerenciadorPagamento.Inserir(pagamento);
                return RedirectToAction(nameof(Index));
            }

            return View(entregaModel);
        }

        // GET: Entrega/Edit/5
        public ActionResult Edit(int id)
        {
            Entrega entrega = gerenciadorEntrega.Obter(id);
            return View(entrega);
        }

        // POST: Entrega/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Entrega entrega)
        {
            if (ModelState.IsValid)
            {
                gerenciadorEntrega.Editar(entrega);
                return RedirectToAction(nameof(Index));
            }

            return View(entrega);
        }

        // GET: Entrega/Delete/5
        public ActionResult Delete(int id)
        {
            Entrega entrega = gerenciadorEntrega.Obter(id);
            return View(entrega);
        }

        // POST: Entrega/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            gerenciadorEntrega.Remover(id);
            return RedirectToAction(nameof(Index));
        }

        private Entrega Atribuir(EntregaModel entrega)
        {
            Entrega e = new Entrega();
            e.CodEntrega = entrega.CodEntrega;
            e.Origem = entrega.Origem;
            e.Destino = entrega.Destino;
            e.Data = DateTime.Now;
            e.Status = "solicitada";
            e.Valor = entrega.Valor;
            e.Duracao = entrega.Duracao;
            e.Distancia = entrega.Distancia;
            e.Descricao_origem = entrega.Descricao_origem;
            e.Descricao_destino = entrega.Descricao_destino;
            e.Categoria_veiculo = entrega.Categoria_veiculo;
            e.CodUsuarioCliente = entrega.CodUsuarioCliente;
            e.CodUsuarioEntregador = entrega.CodUsuarioEntregador;
            e.CodVeiculo = entrega.CodVeiculo;

            return e;
        }
    }
}