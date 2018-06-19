using PSOO.Application.Interfaces.Cadastro;
using PSOO.Application.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PSOO.UI.Web.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly IMunicipioAppService _municipioAppService;

        private void AddErrorsToModelState(List<KeyValuePair<string, string>> erros)
        {
            if (erros == null) return;

            foreach (var erro in erros)
                ModelState.AddModelError(erro.Key, erro.Value);
        }

        public MunicipioController(IMunicipioAppService municipioAppService)
        {
            _municipioAppService = municipioAppService;
        }

        // GET: Cliente
        public ActionResult Index()
        {
            var municipioIndexViewModel = _municipioAppService.GetMunicipioIndexViewModel();
            return View(municipioIndexViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pesquisar(MunicipioIndexViewModel municipioIndexViewModel)
        {
            var listaMunicipioVm = _municipioAppService.GetMunicipioIndexListViewModel(municipioIndexViewModel);

            if (Request.IsAjaxRequest())
                return PartialView("_ListaMunicipios", listaMunicipioVm);

            return View("Index", listaMunicipioVm);
        }

        public ActionResult ListaMunicipios()
        {
            var listamunicipiosVm = _municipioAppService.GetMunicipioIndexListViewModelEmpty();
            return PartialView("_ListaMunicipios", listamunicipiosVm);
        }

        public ActionResult Create()
        {
            var municipioCreateViewModel = _municipioAppService.GetNewMunicipio();
            return View(municipioCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MunicipioCreateViewModel municipioCreateViewModel)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _municipioAppService.CreateMunicipio(municipioCreateViewModel, out erros);
            if (sucesso)
            {
                TempData["Titulo"] = "Sucesso!";
                TempData["Mensagem"] = "Dados inseridos com sucesso!";
                TempData["Link"] = Url.Action("Index", "Municipio");
            }
            else
            {
                AddErrorsToModelState(erros);
            }
            return View(municipioCreateViewModel);
        }

        public ActionResult Edit(int? municipioId)
        {
            if (!municipioId.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var municipioEditViewModel = _municipioAppService.GetEditMunicipio(municipioId.Value);
            return View(municipioEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MunicipioEditViewModel municipioEditViewModel)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _municipioAppService.EditMunicipio(municipioEditViewModel, out erros);
            if (sucesso)
            {
                TempData["Titulo"] = "Sucesso!";
                TempData["Mensagem"] = "Dados alterados com sucesso!";
                TempData["Link"] = Url.Action("Index", "Municipio");
            }
            else
            {
                AddErrorsToModelState(erros);
            }

            return View(municipioEditViewModel);
        }

        public ActionResult Delete(int? municipioId)
        {
            if (!municipioId.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var municipioDeleteViewModel = _municipioAppService.GetDeleteMunicipio(municipioId.Value);
            return View(municipioDeleteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int municipioId)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _municipioAppService.DeleteMunicipio(municipioId, out erros);
            if (sucesso)
            {
                return RedirectToAction("Index", "Municipio");
            }
            else
            {
                AddErrorsToModelState(erros);
                var municipioDeleteViewModel = _municipioAppService.GetDeleteMunicipio(municipioId);
                return View(municipioDeleteViewModel);
            }
        }
    }
}