using PSOO.Domain.Entity.Cadastro;
using PSOO.Domain.Interfaces.Cadastro;
using PSOO.Infra.Data.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Infra.Data.Repository.Cadastro
{
    public class MunicipioRepository:RepositoryBase<Municipio>,IMunicipioRepository
    {
        public MunicipioRepository()
        {

        }

    }
}
