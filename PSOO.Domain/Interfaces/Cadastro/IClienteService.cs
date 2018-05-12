using PSOO.Domain.Entity.Cadastro;
using PSOO.Domain.Interfaces.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Domain.Interfaces.Cadastro
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        void SetSession(ISession session);
    }
}
