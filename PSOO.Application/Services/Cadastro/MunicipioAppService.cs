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
    public class MunicipioAppService : IMunicipioAppService
    {
        private readonly IMunicipioService _MunicipioService;
        private readonly IUnitOfWork _uow;

        public MunicipioAppService(IMunicipioService MunicipioService, IUnitOfWork unitOfWork)
        {
            _MunicipioService = MunicipioService;
            _uow = unitOfWork;
        }

        public MunicipioAppService( )
        { 
        }

        public MunicipioIndexViewModel GetMunicipioIndexViewModel()
        {
            var MunicipioIndexViewModel = new MunicipioIndexViewModel();
            return MunicipioIndexViewModel;
        }

        public IEnumerable<MunicipioIndexListViewModel> GetMunicipioIndexListViewModel(MunicipioIndexViewModel MunicipioIndexViewModel)
        {
            var listaMunicipios = GetListaMunicipios();
            var listaMunicipiosVM = Mapper.Map<IEnumerable<MunicipioIndexListViewModel>>(listaMunicipios);
            return listaMunicipiosVM;
        }

        public IEnumerable<MunicipioIndexListViewModel> GetMunicipioIndexListViewModelEmpty()
        {
            var listaMunicipioVM = new List<MunicipioIndexListViewModel>();
            return listaMunicipioVM;
        }

        public MunicipioCreateViewModel GetNewMunicipio()
        {
            var MunicipioCreateViewModel = new MunicipioCreateViewModel();
            return MunicipioCreateViewModel;
        }

        public bool CreateMunicipio(MunicipioCreateViewModel MunicipioCreateViewModel, out List<KeyValuePair<string, string>> erros)
        {
            erros = null;
            var Municipio = Mapper.Map<Municipio>(MunicipioCreateViewModel);

            var session = _uow.Begin();
            _MunicipioService.SetSession(session);
            if (_MunicipioService.Add(Municipio))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                erros = Municipio.GetValidationsList();
                return false;
            }
        }

        public MunicipioEditViewModel GetEditMunicipio(int MunicipioId)
        {
            var Municipio = GetMunicipio(MunicipioId);
            var MunicipioVM = Mapper.Map<MunicipioEditViewModel>(Municipio);
            return MunicipioVM;
        }

        public bool EditMunicipio(MunicipioEditViewModel MunicipioEditViewModel, out List<KeyValuePair<string, string>> erros)
        {
            erros = null;
            var Municipio = Mapper.Map<Municipio>(MunicipioEditViewModel);

            var session = _uow.Begin();
            _MunicipioService.SetSession(session);
            if (_MunicipioService.Update(Municipio))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                erros = Municipio.GetValidationsList();
                return false;
            }
        }

        public MunicipioDeleteViewModel GetDeleteMunicipio(int MunicipioId)
        {
            var Municipio = GetMunicipio(MunicipioId);
            var MunicipioVM = Mapper.Map<MunicipioDeleteViewModel>(Municipio);
            return MunicipioVM;
        }

        public bool DeleteMunicipio(int MunicipioId, out List<KeyValuePair<string, string>> erros)
        {
            erros = null;
            var Municipio = GetMunicipio(MunicipioId);

            var session = _uow.Begin();
            _MunicipioService.SetSession(session);
            if (_MunicipioService.Remove(Municipio))
            {
                _uow.Commit();
                return true;
            }
            else
            {
                erros = Municipio.GetValidationsList();
                return false;
            }
        }


        private Municipio GetMunicipio(int MunicipioId)
        {
            var session = _uow.Begin();
            _MunicipioService.SetSession(session);
            var Municipio = _MunicipioService.GetById(MunicipioId);
            _uow.Commit();
            return Municipio;
        }

        private IEnumerable<Municipio> GetListaMunicipios()
        {
            var session = _uow.Begin();
            _MunicipioService.SetSession(session);
            var lista = _MunicipioService.GetAll();
            _uow.Commit();
            return lista;
        }
    }
}