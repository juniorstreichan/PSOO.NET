using PSOO.Application.Interfaces.Cadastro;
using PSOO.Application.ViewModel;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace PSOO.UI.Web.Controllers
{
    public class MunicipioController : Controller
    {
        private readonly IMunicipioAppService _MunicipioAppService;

        public MunicipioController()
        {

        }

        private void AddErrorsToModelState(List<KeyValuePair<string, string>> erros)
        {
            if (erros == null) return;

            foreach (var erro in erros)
                ModelState.AddModelError(erro.Key, erro.Value);
        }

        public MunicipioController(IMunicipioAppService MunicipioAppService)
        {
            _MunicipioAppService = MunicipioAppService;
        }

        // GET: Municipio
        public ActionResult Index()
        {
            var MunicipioIndexViewModel = _MunicipioAppService.GetMunicipioIndexViewModel();
            return View(MunicipioIndexViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pesquisar(MunicipioIndexViewModel MunicipioIndexViewModel)
        {
            var listaMunicipioVm = _MunicipioAppService.GetMunicipioIndexListViewModel(MunicipioIndexViewModel);

            if (Request.IsAjaxRequest())
                return PartialView("_ListaMunicipios", listaMunicipioVm);

            return View("Index", listaMunicipioVm);
        }

        public ActionResult ListaMunicipios()
        {
            var listaMunicipiosVm = _MunicipioAppService.GetMunicipioIndexListViewModelEmpty();
            return PartialView("_ListaMunicipios", listaMunicipiosVm);
        }

        public ActionResult Create()
        {
            var MunicipioCreateViewModel = _MunicipioAppService.GetNewMunicipio();
            return View(MunicipioCreateViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MunicipioCreateViewModel MunicipioCreateViewModel)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _MunicipioAppService.CreateMunicipio(MunicipioCreateViewModel, out erros);
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
            return View(MunicipioCreateViewModel);
        }

        public ActionResult Edit(int? MunicipioId)
        {
            if (!MunicipioId.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var MunicipioEditViewModel = _MunicipioAppService.GetEditMunicipio(MunicipioId.Value);
            return View(MunicipioEditViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MunicipioEditViewModel MunicipioEditViewModel)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _MunicipioAppService.EditMunicipio(MunicipioEditViewModel, out erros);
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

            return View(MunicipioEditViewModel);
        }

        public ActionResult Delete(int? MunicipioId)
        {
            if (!MunicipioId.HasValue) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var MunicipioDeleteViewModel = _MunicipioAppService.GetDeleteMunicipio(MunicipioId.Value);
            return View(MunicipioDeleteViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int MunicipioId)
        {
            List<KeyValuePair<string, string>> erros = null;
            var sucesso = _MunicipioAppService.DeleteMunicipio(MunicipioId, out erros);
            if (sucesso)
            {
                return RedirectToAction("Index", "Municipio");
            }
            else
            {
                AddErrorsToModelState(erros);
                var cursoDeleteViewModel = _MunicipioAppService.GetDeleteMunicipio(MunicipioId);
                return View(cursoDeleteViewModel);
            }
        }
    }
}