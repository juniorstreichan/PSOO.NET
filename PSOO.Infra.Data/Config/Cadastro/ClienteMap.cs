using FluentNHibernate.Mapping;
using PSOO.Domain.Entity.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Infra.Data.Config.Cadastro
{
    public class ClienteMap : ClassMap<Cliente>
    {
        public ClienteMap()
        {
            Schema("dbo");
            Table("cliente");
            Id(x => x.ClienteId).Column("clienteid").GeneratedBy.Identity();
            Map(x => x.Nome).Column("nome").Not.Nullable().Length(Cliente.NomeMaxLength);
            Map(x => x.NomeFantasia).Column("nomefantasia").Length(Cliente.NomeFantasiaMaxLength);
            Map(x => x.CNPJ).Column("cnpj").Not.Nullable().Length(Cliente.CNPJMaxLength);
        }
    }
}
