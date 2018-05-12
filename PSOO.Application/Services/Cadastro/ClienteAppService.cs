using AutoMapper;
using PSOO.Application.Interfaces.Cadastro;
using PSOO.Application.ViewModel;
using PSOO.Domain.Entity.Cadastro;
using PSOO.Domain.Interfaces.Cadastro;
using PSOO.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Application.Services.Cadastro
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;
        private readonly IUnitOfWork _uow;

        public ClienteAppService(IClienteService clienteService, IUnitOfWork unitOfWork)
        {
            _clienteService = clienteService;
            _uow = unitOfWork;
        }

        public ClienteIndexViewModel GetClienteIndexViewModel()
        {
            var clienteIndexViewModel = new ClienteIndexViewModel();
            return clienteIndexViewModel;
        }

        public IEnumerable<ClienteIndexListViewModel> GetClienteIndexListViewModel(ClienteIndexViewModel clienteIndexViewModel)
        {
            var listaClientes = GetListaClientes();
            var listaClientesVM = Mapper.Map<IEnumerable<ClienteIndexListViewModel>>(listaClientes);
            return listaClientesVM;
        }

        public IEnumerable<ClienteIndexListViewModel> GetClienteIndexListViewModelEmpty()
        {
            var listaClienteVM = new List<ClienteIndexListViewModel>();
            return listaClienteVM;
        }

        public ClienteCreateViewModel GetNewCliente()
        {
            var clienteCreateViewModel = new ClienteCreateViewModel();
            return clienteCreateViewModel;
        }

        public bool CreateCliente(ClienteCreateViewModel clienteCreateViewModel, out List<KeyValuePair<string, string>> erros)
        {
            erros = null;
            var cliente = Mapper.Map<Cliente>(clienteCreateViewModel);

            var session = _uow.Begin();
            _clienteService.SetSession(session);
            if (_clienteService.Add(cliente))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                erros = cliente.GetValidationsList();
                return false;
            }
        }

        public ClienteEditViewModel GetEditCliente(int clienteId)
        {
            var cliente = GetCliente(clienteId);
            var clienteVM = Mapper.Map<ClienteEditViewModel>(cliente);
            return clienteVM;
        }

        public bool EditCliente(ClienteEditViewModel clienteEditViewModel, out List<KeyValuePair<string, string>> erros)
        {
            erros = null;
            var cliente = Mapper.Map<Cliente>(clienteEditViewModel);

            var session = _uow.Begin();
            _clienteService.SetSession(session);
            if (_clienteService.Update(cliente))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                erros = cliente.GetValidationsList();
                return false;
            }
        }

        public ClienteDeleteViewModel GetDeleteCliente(int clienteId)
        {
            var cliente = GetCliente(clienteId);
            var clienteVM = Mapper.Map<ClienteDeleteViewModel>(cliente);
            return clienteVM;
        }

        public bool DeleteCliente(int clienteId, out List<KeyValuePair<string, string>> erros)
        {
            erros = null;
            var cliente = GetCliente(clienteId);

            var session = _uow.Begin();
            _clienteService.SetSession(session);
            if (_clienteService.Remove(cliente))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                erros = cliente.GetValidationsList();
                return false;
            }
        }


        private Cliente GetCliente(int clienteId)
        {
            var session = _uow.Begin();
            _clienteService.SetSession(session);
            var cliente = _clienteService.GetById(clienteId);
            _uow.Commit();
            return cliente;
        }

        private IEnumerable<Cliente> GetListaClientes()
        {
            var session = _uow.Begin();
            _clienteService.SetSession(session);
            var lista = _clienteService.GetAll();
            _uow.Commit();
            return lista;
        }
    }
}