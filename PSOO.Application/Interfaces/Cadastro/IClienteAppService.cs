using PSOO.Application.ViewModel;
using System.Collections.Generic;

namespace PSOO.Application.Interfaces.Cadastro
{
    public interface IClienteAppService
    {
        ClienteIndexViewModel GetClienteIndexViewModel();
        IEnumerable<ClienteIndexListViewModel> GetClienteIndexListViewModel(ClienteIndexViewModel cursoIndexViewModel);
        IEnumerable<ClienteIndexListViewModel> GetClienteIndexListViewModelEmpty();
        ClienteCreateViewModel GetNewCliente();
        bool CreateCliente(ClienteCreateViewModel cursoCreateViewModel, out List<KeyValuePair<string, string>> erros);
        ClienteEditViewModel GetEditCliente(int cursoId);
        bool EditCliente(ClienteEditViewModel cursoEditViewModel, out List<KeyValuePair<string, string>> erros);
        ClienteDeleteViewModel GetDeleteCliente(int cursoId);
        bool DeleteCliente(int cursoId, out List<KeyValuePair<string, string>> erros);
    }
}
