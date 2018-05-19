using FluentValidation;
using PSOO.Domain.Entity.Cadastro;
using PSOO.Domain.Interfaces.Cadastro;
using PSOO.Domain.Interfaces.Common;
using PSOO.Domain.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Domain.Services.Cadastro
{
    public class ClienteService :ServiceBase<Cliente>, IClienteService
    {

        private readonly IClienteRepository _clienteRepository;
        private readonly IClienteValidator _clienteValidator;



        public ClienteService(IClienteRepository repository, IClienteValidator validator) : base(repository, validator)
        {
            _clienteRepository = repository;
            _clienteValidator = validator;
            _clienteValidator.SetService(this);
        }

        public void SetSession(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
