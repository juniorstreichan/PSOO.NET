using FluentNHibernate.Mapping;
using PSOO.Domain.Entity.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Infra.Data.Config.Cadastro
{
    public class MunicipioMap : ClassMap<Municipio>
    {
        public MunicipioMap()
        {
            Schema("dbo");
            Table("Municipio");
            Id(x => x.MunicipioId).Column("MunicipioId").GeneratedBy.Identity();
            Map(x => x.Nome).Column("Nome").Not.Nullable().Length(Municipio.NomeMaxLength);
            Map(x => x.CodigoIBGE).Column("CodigoIBGE").Not.Nullable().Length(Municipio.CodigoIBGEMaxLength);
            Map(x => x.SiglaUf).Column("SiglaUF").Not.Nullable().Length(Municipio.SiglaUFMaxLength);
            Map(x => x.CodigoIBGEUF).Column("CodigoIBGEUF").Not.Nullable().Length(Municipio.CodigoIBGEUFMaxLength);
            Map(x => x.NomePais).Column("NomePais").Not.Nullable().Length(Municipio.NomePaisMaxLength);
            Map(x => x.CodigoPaisBACEN).Column("CodigoPaisBACEN").Not.Nullable();
        }
    }
}
