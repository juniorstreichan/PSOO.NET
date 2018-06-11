using PSOO.Application.ViewModel;
using System.Collections.Generic;

namespace PSOO.Application.Interfaces.Cadastro
{
    public interface IClienteAppService
    {
        ClienteIndexViewModel GetClienteIndexViewModel();
        IEnumerable<ClienteIndexListViewModel> GetClienteIndexListViewModel(ClienteIndexViewModel clienteIndexViewModel);
        IEnumerable<ClienteIndexListViewModel> GetClienteIndexListViewModelEmpty();
        ClienteCreateViewModel GetNewCliente();
        bool CreateCliente(ClienteCreateViewModel clienteCreateViewModel, out List<KeyValuePair<string, string>> erros);
        ClienteEditViewModel GetEditCliente(int clienteId);
        bool EditCliente(ClienteEditViewModel clienteEditViewModel, out List<KeyValuePair<string, string>> erros);
        ClienteDeleteViewModel GetDeleteCliente(int clienteId);
        bool DeleteCliente(int clienteId, out List<KeyValuePair<string, string>> erros);
    }
}
