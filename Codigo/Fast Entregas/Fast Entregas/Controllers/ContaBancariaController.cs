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
    public class ContaBancariaController : Controller
    {
        private readonly IGerenciadorContaBancaria gerenciadorContaBancaria;

        public ContaBancariaController(IGerenciadorContaBancaria _gerenciadorContaBancaria)
        {
            gerenciadorContaBancaria = _gerenciadorContaBancaria;
        }

        // GET: ContaBancaria
        public ActionResult Index()
        {
            return View(gerenciadorContaBancaria.ObterTodas());
        }

        // GET: ContaBancaria/Details/5
        public ActionResult Details(int codigo)
        {
            ContaBancaria contabancaria = gerenciadorContaBancaria.Obter(codigo);
            return View(contabancaria);
        }

        // GET: ContaBancaria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContaBancaria/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContaBancaria contabancaria)
        {
            if (ModelState.IsValid)
            {
                gerenciadorContaBancaria.Inserir(contabancaria);
                return RedirectToAction(nameof(Index));
            }

            return View(contabancaria);
        }

        // GET: ContaBancaria/Edit/5
        public ActionResult Edit(int codigo)
        {
            ContaBancaria contabancaria = gerenciadorContaBancaria.Obter(codigo);
            return View(contabancaria);
        }

        // POST: ContaBancaria/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int codigo, ContaBancaria contabancaria)
        {
            if (ModelState.IsValid)
            {
                gerenciadorContaBancaria.Editar(contabancaria);
                return RedirectToAction(nameof(Index));
            }
            return View(contabancaria);
        }

        // GET: ContaBancaria/Delete/5
        public ActionResult Delete(int codigo)
        {
            ContaBancaria contabancariaModel = gerenciadorContaBancaria.Obter(codigo);
            return View(contabancariaModel);
        }

        // POST: ContaBancaria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int codigo, IFormCollection collection)
        {
            gerenciadorContaBancaria.Remover(codigo);
            return RedirectToAction(nameof(Index));
        }
    }
}