using FluentValidation;
using PSOO.Domain.Entity.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Domain.Interfaces.Cadastro
{
   public interface IMunicipioValidator : IValidator<Municipio>
    {
        void SetService(IMunicipioService service);
    }
}
