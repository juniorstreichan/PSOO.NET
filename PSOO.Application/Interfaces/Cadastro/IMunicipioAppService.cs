using PSOO.Application.ViewModel;
using System.Collections.Generic;

namespace PSOO.Application.Interfaces.Cadastro
{
    public interface IMunicipioAppService
    {
        MunicipioIndexViewModel GetMunicipioIndexViewModel();
        IEnumerable<MunicipioIndexListViewModel> GetMunicipioIndexListViewModel(MunicipioIndexViewModel MunicipioIndexViewModel);
        IEnumerable<MunicipioIndexListViewModel> GetMunicipioIndexListViewModelEmpty();
        MunicipioCreateViewModel GetNewMunicipio();
        bool CreateMunicipio(MunicipioCreateViewModel MunicipioCreateViewModel, out List<KeyValuePair<string, string>> erros);
        MunicipioEditViewModel GetEditMunicipio(int MunicipioId);
        bool EditMunicipio(MunicipioEditViewModel MunicipioEditViewModel, out List<KeyValuePair<string, string>> erros);
        MunicipioDeleteViewModel GetDeleteMunicipio(int MunicipioId);
        bool DeleteMunicipio(int MunicipioId, out List<KeyValuePair<string, string>> erros);
    }
}
