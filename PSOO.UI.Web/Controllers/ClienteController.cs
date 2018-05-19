using PSOO.Application.Interfaces.Cadastro;
using PSOO.Application.ViewModel;
using System.Web.Mvc;

namespace PSOO.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;

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
    }
}