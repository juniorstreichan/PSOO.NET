using AutoMapper;
using PSOO.Application.ViewModel;
using PSOO.Domain.Entity.Cadastro;

namespace PSOO.Application.AutoMapper.Cadastro
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            //IDA
            CreateMap<Cliente, ClienteIndexListViewModel>();

            CreateMap<Cliente, ClienteEditViewModel>();

            CreateMap<Cliente, ClienteDeleteViewModel>();

            //VOLTA
            CreateMap<ClienteCreateViewModel, Cliente>();

            CreateMap<ClienteEditViewModel, Cliente>();

            CreateMap<ClienteDeleteViewModel, Cliente>();
        }
    }
}
