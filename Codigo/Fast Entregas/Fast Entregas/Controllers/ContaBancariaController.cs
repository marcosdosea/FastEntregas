using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Persistence;
using Services;

namespace FastEntregasWeb.Controllers
{
    [Authorize]
    public class ContaBancariaController : Controller
    {
        private readonly IGerenciadorContaBancaria gerenciadorContaBancaria;
        private readonly IGerenciadorBanco gerenciadorBanco;


        public ContaBancariaController(IGerenciadorContaBancaria _gerenciadorContaBancaria, IGerenciadorBanco _gerenciadorBanco)
        {
            gerenciadorContaBancaria = _gerenciadorContaBancaria;
            gerenciadorBanco = _gerenciadorBanco;
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
            ViewBag.codBanco = new SelectList(gerenciadorBanco.ObterTodos(), "CodBanco", "Nome");
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
        public ActionResult Delete(int id)
        {
            ContaBancaria contabancariaModel = gerenciadorContaBancaria.Obter(id);
            return View(contabancariaModel);
        }

        // POST: ContaBancaria/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            gerenciadorContaBancaria.Remover(id);
            return RedirectToAction(nameof(Index));
        }
    }
}