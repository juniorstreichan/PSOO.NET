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
    public class MunicipioService :ServiceBase<Municipio>, IMunicipioService
    {

        private readonly IMunicipioRepository _MunicipioRepository;
        private readonly IMunicipioValidator _MunicipioValidator;



        public MunicipioService(IMunicipioRepository repository, IMunicipioValidator validator) : base(repository, validator)
        {
            _MunicipioRepository = repository;
            _MunicipioValidator = validator;
            _MunicipioValidator.SetService(this);
        }

        public void SetSession(ISession session)
        {
            throw new NotImplementedException();
        }
    }
}
