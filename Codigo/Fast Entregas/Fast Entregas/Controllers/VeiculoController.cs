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
    public class VeiculoController : Controller
    {
        private readonly IGerenciadorVeiculo gerenciadorVeiculo;
        private readonly IGerenciadorUsuario gerenciadorUsuario;

        public VeiculoController(IGerenciadorVeiculo _gerenciadorVeiculo, IGerenciadorUsuario _gerenciadorUsuario)
        {
            gerenciadorVeiculo = _gerenciadorVeiculo;
            gerenciadorUsuario = _gerenciadorUsuario;
        }

        // GET: Veiculo
        public ActionResult Index()
        {
            string username = User.Identity.Name;
            var usuario = gerenciadorUsuario.ObterPorUserName(username);
            if(usuario != null)
            {
                return View(gerenciadorVeiculo.ObterTodos()
                    .Where(veiculo => veiculo.CodDono.Equals(usuario.CodUsuario)));
            }
            return View();
        }

        // GET: Veiculo/Details/5
        public ActionResult Details(int id)
        {
            Veiculo veiculo = gerenciadorVeiculo.Obter(id);
            return View(veiculo);
        }

        // GET: Veiculo/Create
        public ActionResult Create()
        {
            string username = User.Identity.Name;
            var usuario = gerenciadorUsuario.ObterPorUserName(username);
            if (usuario != null)
            {
                ViewBag.codUsuario = usuario.CodUsuario;
                return View();
            }
            return View();
        }

        // POST: Veiculo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Veiculo veiculo)
        {
            veiculo.EmUso = "Nao";
            veiculo.Status = "disponivel";
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