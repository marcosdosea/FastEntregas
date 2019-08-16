using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace FastEntregasWeb.Controllers
{
    public class SolicitacaoDeCadastroController : Controller
    {
        private readonly IGerenciadorSolicitacaoDeCadastro gerenciadorSolicitacaoDeCadastro;

        public SolicitacaoDeCadastroController(IGerenciadorSolicitacaoDeCadastro _gerenciadorSolicitacaoDeCadastro)
        {
            gerenciadorSolicitacaoDeCadastro = _gerenciadorSolicitacaoDeCadastro;
        }
        
        // GET: SolicitacaoDeCadastro
        public ActionResult Index(int id)
        {
            IEnumerable<SolicitacaoDeCadastro> solicitacoes = gerenciadorSolicitacaoDeCadastro.ObterTodos().Where(solicitacao => solicitacao.Status.StartsWith("solicitada") || solicitacao.Status.StartsWith("em analise"));            
            ViewBag.codFuncionario = id;
            return View(solicitacoes);
        }

        //GET: SolicitacaoDeCadastro/Avaliar
        public ActionResult Avaliar(int id, int codFuncionario)
        {
            SolicitacaoDeCadastro solicitacao = gerenciadorSolicitacaoDeCadastro.Obter(id);
            if (solicitacao.Status == "solicitada")
            {
                solicitacao.CodUsuarioFuncionario = codFuncionario;
                solicitacao.Status = "em analise";
            }
            if (ModelState.IsValid)
            {
                gerenciadorSolicitacaoDeCadastro.Editar(solicitacao);
            }
            return View(solicitacao);
        }

        public ActionResult Aprovar(int id, string avaliacao)
        {
            SolicitacaoDeCadastro solicitacao = gerenciadorSolicitacaoDeCadastro.Obter(id);
            solicitacao.Status = avaliacao;
            if (ModelState.IsValid)
            {
                gerenciadorSolicitacaoDeCadastro.Editar(solicitacao);
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: SolicitacaoDeCadastro/Details/5
        public ActionResult Details(int codigo)
        {
            SolicitacaoDeCadastro solicitacao = gerenciadorSolicitacaoDeCadastro.Obter(codigo);
            return View(solicitacao);
        }

        /// <summary>
        /// Mostrar todas as solicitações de cadastro feitas por um usuário específico
        /// </summary>
        /// <param name="id">Código do usuario</param>
        /// <returns></returns>

        // GET: SolicitacaoDeCadastro/DetailsMultiple/5
        public ActionResult DetailsMultiple(int id)
        {
            IEnumerable<SolicitacaoDeCadastro> solicitacaoDeCadastro = gerenciadorSolicitacaoDeCadastro.ObterTodos().Where(solicitacao => solicitacao.CodUsuarioEntregador.Equals(id));
            ViewBag.solicitacaoEmAndamento = true;
            foreach (var item in solicitacaoDeCadastro)
            {
                if (item.Status != "reprovada")
                {
                    ViewBag.solicitacaoEmAndamento = false;
                }
            }
            return View(solicitacaoDeCadastro);
        }

        /// <summary>
        /// Criar nova solicitação de cadastro já com o código do usuário que vai solicitar
        /// </summary>
        /// <param name="id"> Código do usuário </param>
        /// <returns></returns>
        
        // GET: SolicitacaoDeCadastro/Create
        public ActionResult Create(int id)
        {
            ViewBag.codUsuario = id;
            return View();
        }

        // POST: SolicitacaoDeCadastro/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SolicitacaoDeCadastro solicitacao)
        {
            if (ModelState.IsValid)
            {
                gerenciadorSolicitacaoDeCadastro.Inserir(solicitacao);
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }

        // GET: SolicitacaoDeCadastro/Edit/5
        public ActionResult Edit(int id)
        {
            SolicitacaoDeCadastro solicitacao = gerenciadorSolicitacaoDeCadastro.Obter(id);
            return View(solicitacao);
        }

        // POST: SolicitacaoDeCadastro/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SolicitacaoDeCadastro solicitacao)
        {
            if (ModelState.IsValid)
            {
                gerenciadorSolicitacaoDeCadastro.Editar(solicitacao);
                return RedirectToAction(nameof(Index));
            }
            return View(solicitacao);
        }

        // GET: SolicitacaoDeCadastro/Delete/5
        public ActionResult Delete(int id)
        {
            SolicitacaoDeCadastro solicitacao = gerenciadorSolicitacaoDeCadastro.Obter(id);
            return View(solicitacao);
        }

        // POST: SolicitacaoDeCadastro/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SolicitacaoDeCadastro solicitacao)
        {
            gerenciadorSolicitacaoDeCadastro.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}