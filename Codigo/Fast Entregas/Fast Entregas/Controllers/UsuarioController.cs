using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Model;
using Microsoft.AspNetCore.Authorization;

namespace FastEntregasWeb.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IGerenciadorUsuario gerenciadorUsuario;
        private readonly IGerenciadorSolicitacaoDeCadastro gerenciadorSolicitacao;

        public UsuarioController(IGerenciadorUsuario _gerenciadorUsuario, IGerenciadorSolicitacaoDeCadastro _gerenciadorSolicitacao)
        {
            gerenciadorUsuario = _gerenciadorUsuario;
            gerenciadorSolicitacao = _gerenciadorSolicitacao;
        }

        // GET: Usuario
        public ActionResult Index()
        {
            return View(gerenciadorUsuario.ObterTodos());
        }

        /// <summary>
        /// Redireciona o usuário para solicitar cadastro para ser entregador ou redireciona para as solicitações de cadastro já solicitadas
        /// </summary>
        /// <param name="id">Código do Usuário</param>
        /// <returns></returns>
        
        // GET: Usuario/SolicitarCadastro
        public ActionResult SolicitarCadastro(int id)
        {
            //Usuario usuario = gerenciadorUsuario.Obter(id);
            IEnumerable<SolicitacaoDeCadastro> solicitacaoDeCadastro = gerenciadorSolicitacao.ObterTodos().Where(solicitacao => solicitacao.CodUsuarioEntregador.Equals(id));

            if (solicitacaoDeCadastro.ToList().Count() == 0)
            {
                return RedirectToAction("Create", "SolicitacaoDeCadastro", new { id = id });
            }

            return RedirectToAction("DetailsMultiple", "SolicitacaoDeCadastro", new { id = id });
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int codigo)
        {
            Usuario usuario = gerenciadorUsuario.Obter(codigo);
            return View(usuario);
        }


        // GET: Usuario/Create
        public ActionResult Create(string id)
        {
            ViewBag.userName = id;
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                gerenciadorUsuario.Inserir(usuario);
                return RedirectToAction("Index", "Home");
            }

            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = gerenciadorUsuario.Obter(id);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                gerenciadorUsuario.Editar(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuarioModel = gerenciadorUsuario.Obter(id);
            return View(usuarioModel);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Usuario usuario)
        {
            gerenciadorUsuario.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}