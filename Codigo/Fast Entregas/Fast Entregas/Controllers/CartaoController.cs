using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;
using System.Linq;

namespace FastEntregasWeb.Controllers
{
    [Authorize]
    public class CartaoController : Controller
    {
        private readonly IGerenciadorCartao gerenciadorCartao;
        private readonly IGerenciadorUsuario gerenciadorUsuario;

        public CartaoController(IGerenciadorCartao _gerenciadorCartao, IGerenciadorUsuario _gerenciadorUsuario)
        {
            gerenciadorCartao = _gerenciadorCartao;
            gerenciadorUsuario = _gerenciadorUsuario;
        }

        // GET: Cartao
        public ActionResult Index()
        {
            string userName = User.Identity.Name;
            var usuario = gerenciadorUsuario.ObterPorUserName(userName);
            if (usuario != null)
            {
                return View(gerenciadorCartao.ObterTodos()
                    .Where(cartao => cartao.CodUsuario.Equals(usuario.CodUsuario)));
            }
            return View();
        }

        // GET: Cartao/Details/5
        public ActionResult Details(int id)
        {
            Cartao cartao = gerenciadorCartao.Obter(id);
            return View(cartao);
        }

        // GET: Cartao/Create
        public ActionResult Create()
        {
            string userName = User.Identity.Name;
            var usuario = gerenciadorUsuario.ObterPorUserName(userName);
            if (usuario != null)
            {
                ViewBag.codUsuario = usuario.CodUsuario;
                return View();
            }
            return RedirectToAction("Create", "Entrega");
        }

        // POST: Cartao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                gerenciadorCartao.Inserir(cartao);
                return RedirectToAction(nameof(Index));
            }

            return View(cartao);

        }

        // GET: Cartao/Edit/5
        public ActionResult Edit(int id)
        {
            Cartao cartao = gerenciadorCartao.Obter(id);
            return View(cartao);
        }

        // POST: Cartao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int codCartao, Cartao cartao)
        {
            if (ModelState.IsValid)
            {
                gerenciadorCartao.Editar(cartao);
                return RedirectToAction(nameof(Index));
            }

            return View(cartao);

        }

        // GET: Cartao/Delete/5
        public ActionResult Delete(int id)
        {
            Cartao cartaoModel = gerenciadorCartao.Obter(id);
            return View(cartaoModel);
        }

        // POST: Cartao/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            gerenciadorCartao.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
