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
    public class VeiculoController : Controller
    {
        private readonly IGerenciadorVeiculo gerenciadorVeiculo;

        public VeiculoController(IGerenciadorVeiculo _gerenciadorVeiculo)
        {
            gerenciadorVeiculo = _gerenciadorVeiculo;
        }

        // GET: Veiculo
        public ActionResult Index()
        {
            return View(gerenciadorVeiculo.ObterTodos());
        }

        // GET: Veiculo/Details/5
        public ActionResult Details(int codigo)
        {
            Veiculo veiculo = gerenciadorVeiculo.Obter(codigo);
            return View(veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Veiculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                gerenciadorVeiculo.Inserir(veiculo);
                return RedirectToAction(nameof(Index));
            }
           
            return View(veiculo);
            
        }

        // GET: Veiculo/Edit/5
        public ActionResult Edit(int codigo)
        {
            Veiculo veiculo = gerenciadorVeiculo.Obter(codigo);
            return View(veiculo);
        }

        // POST: Veiculo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int codigo, Veiculo veiculo)
        {
            if (ModelState.IsValid)
            {
                gerenciadorVeiculo.Editar(veiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // GET: Veiculo/Delete/5
        public ActionResult Delete(int id)
        {
            Veiculo veiculoModel = gerenciadorVeiculo.Obter(id);
            return View(veiculoModel);
        }

        // POST: Veiculo/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            gerenciadorVeiculo.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}