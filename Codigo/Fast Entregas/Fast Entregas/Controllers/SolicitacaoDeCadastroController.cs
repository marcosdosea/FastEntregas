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
    public class SolicitacaoDeCadastroController : Controller
    {
        private readonly IGerenciadorSolicitacaoDeCadastro gerenciadorSolicitacaoDeCadastro;
        private readonly IGerenciadorUsuario gerenciadorUsuario;

        public SolicitacaoDeCadastroController(IGerenciadorSolicitacaoDeCadastro _gerenciadorSolicitacaoDeCadastro, IGerenciadorUsuario _gerenciadorUsuario)
        {
            gerenciadorSolicitacaoDeCadastro = _gerenciadorSolicitacaoDeCadastro;
            gerenciadorUsuario = _gerenciadorUsuario;
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
            string userName = User.Identity.Name;
            var usuario = gerenciadorUsuario.ObterPorUserName(userName);
            IEnumerable<SolicitacaoDeCadastro> solicitacaoDeCadastro = null;
            if (usuario != null)
            {                
                solicitacaoDeCadastro = gerenciadorSolicitacaoDeCadastro.ObterTodos()
                    .Where(solicitacao => solicitacao.CodUsuarioEntregador
                    .Equals(usuario.CodUsuario));

                ViewBag.solicitacaoEmAndamento = true;
                foreach (var item in solicitacaoDeCadastro)
                {
                    if (item.Status != "reprovada")
                    {
                        ViewBag.solicitacaoEmAndamento = false;
                    }
                }
            }
            return View(solicitacaoDeCadastro);
        }

        /// <summary>
        /// Consultar Histórico de solitações analisadas 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DetailsHistoricoSolicitacaoAnalisadas(int id)
        {
            IEnumerable<SolicitacaoDeCadastro> solicitacaoDeCadastros = gerenciadorSolicitacaoDeCadastro.ObterTodos().Where(solicitacao => solicitacao.CodUsuarioFuncionario.Equals(id));
            return View(solicitacaoDeCadastros);
        }

        /// <summary>
        /// Criar nova solicitação de cadastro
        /// </summary>
        /// <param></param>
        /// <returns></returns>

        // GET: SolicitacaoDeCadastro/Create
        public ActionResult Create()
        {
            string userName = User.Identity.Name;
            var usuario = gerenciadorUsuario.ObterPorUserName(userName);
            if (usuario != null)
            {
                IEnumerable<SolicitacaoDeCadastro> solicitacaoDeCadastro = null;
                solicitacaoDeCadastro = gerenciadorSolicitacaoDeCadastro.ObterTodos()
                    .Where(solicitacao => solicitacao.CodUsuarioEntregador
                    .Equals(usuario.CodUsuario));
                if (solicitacaoDeCadastro.Count() == 0)
                {
                    ViewBag.codUsuario = usuario.CodUsuario;
                    return View();
                }
                else
                {
                    return RedirectToAction(nameof(DetailsMultiple));
                }

            }
            return RedirectToAction("Create", "Entrega");
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
            return RedirectToAction(nameof(DetailsMultiple));
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