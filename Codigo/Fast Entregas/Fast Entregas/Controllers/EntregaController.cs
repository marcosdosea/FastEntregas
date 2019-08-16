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
    public class EntregaController : Controller
    {
        private readonly IGerenciadorEntrega gerenciadorEntrega;

        public EntregaController(IGerenciadorEntrega _gerenciadorEntrega)
        {
            gerenciadorEntrega = _gerenciadorEntrega;
        }

        // GET: Entrega
        public ActionResult Index()
        {
            return View(gerenciadorEntrega.ObterTodos());
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
            return View();
        }

        // POST: Entrega/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Entrega entrega)
        {
            entrega.Data = DateTime.Now;
            entrega.Status = "solicitada";
            if (ModelState.IsValid)
            {
                gerenciadorEntrega.Inserir(entrega);
                return RedirectToAction(nameof(Index));
            }

            return View(entrega);
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
    }
}