using PSOO.Application.Interfaces.Cadastro;
using PSOO.Application.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PSOO.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

        private void AddErrorsToModelState(List<KeyValuePair<string, string>> erros)
        {
            if (erros == null) return;

            foreach (var erro in erros)
                ModelState.AddModelError(erro.Key, erro.Value);
        }

        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var clienteIndexViewModel = _clienteAppService.GetClienteIndexViewModel();
            return View(clienteIndexViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pesquisar(ClienteIndexViewModel clienteIndexViewModel)
        {
            var listaClienteVm = _clienteAppService.GetClienteIndexListViewModel(clienteIndexViewModel);

            if (Request.IsAjaxRequest())
                return PartialView("_ListaClientes", listaClienteVm);

            return View("Index", listaClienteVm);
        }

        public ActionResult ListaClientes()
        {
            var listaclientesVm = _clienteAppService.GetClienteIndexListViewModelEmpty();
            return PartialView("_ListaClientes", listaclientesVm);
        }

        public ActionResult Create()
        {
            var clienteCreateViewModel = _clienteAppService.GetNewCliente();
            return View(clienteCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteCreateViewModel clienteCreateViewModel)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _clienteAppService.CreateCliente(clienteCreateViewModel, out erros);
            if (sucesso)
            {
                TempData["Titulo"] = "Sucesso!";
                TempData["Mensagem"] = "Dados inseridos com sucesso!";
                TempData["Link"] = Url.Action("Index", "Curso");
            }
            else
            {
                AddErrorsToModelState(erros);
            }
            return View(clienteCreateViewModel);
        }

        public ActionResult Edit(int? clienteId)
        {
            if (!clienteId.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteEditViewModel = _clienteAppService.GetEditCliente(clienteId.Value);
            return View(clienteEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteEditViewModel clienteEditViewModel)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _clienteAppService.EditCliente(clienteEditViewModel, out erros);
            if (sucesso)
            {
                TempData["Titulo"] = "Sucesso!";
                TempData["Mensagem"] = "Dados alterados com sucesso!";
                TempData["Link"] = Url.Action("Index", "Cliente");
            }
            else
            {
                AddErrorsToModelState(erros);
            }

            return View(clienteEditViewModel);
        }

        public ActionResult Delete(int? clienteId)
        {
            if (!clienteId.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var clienteDeleteViewModel = _clienteAppService.GetDeleteCliente(clienteId.Value);
            return View(clienteDeleteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int clienteId)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _clienteAppService.DeleteCliente(clienteId, out erros);
            if (sucesso)
            {
                return RedirectToAction("Index", "Cliente");
            }
            else
            {
                AddErrorsToModelState(erros);
                var cursoDeleteViewModel = _clienteAppService.GetDeleteCliente(clienteId);
                return View(cursoDeleteViewModel);
            }
        }
    }
}