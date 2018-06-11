using AutoMapper;
using PSOO.Application.ViewModel;
using PSOO.Domain.Entity.Cadastro;

namespace PSOO.Application.AutoMapper.Cadastro
{
    public class MunicipioProfile : Profile
    {
        public MunicipioProfile()
        {
            //IDA
            CreateMap<Municipio, MunicipioIndexListViewModel>();

            CreateMap<Municipio, MunicipioEditViewModel>();

            CreateMap<Municipio, MunicipioDeleteViewModel>();

            //VOLTA
            CreateMap<MunicipioCreateViewModel, Municipio>();

            CreateMap<MunicipioEditViewModel, Municipio>();

            CreateMap<MunicipioDeleteViewModel, Municipio>();
        }
    }
}
