    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace FastEntregasWeb.Controllers
{
    public class CartaoController : Controller
    {

        private readonly IGerenciadorCartao gerenciadorCartao;

        public CartaoController(IGerenciadorCartao _gerenciadorCartao)
        {
            gerenciadorCartao = _gerenciadorCartao;
        }

        // GET: Cartao
        public ActionResult Index()
        {
            return View(gerenciadorCartao.ObterTodos());
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
            return View();
        }

        // POST: Cartao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cartao cartao)
        {
            if(ModelState.IsValid)
            {
                // TODO: Add insert logic here
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
            if(ModelState.IsValid)
            {
                // TODO: Add update logic here
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