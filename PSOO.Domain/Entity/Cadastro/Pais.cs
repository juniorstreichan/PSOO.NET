using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.Domain.Entity.Cadastro
{
    public class Pais
    {
        public virtual int PaisId { get; set; }
        public virtual string Nome { get; set; }
        public virtual string CodigoBACEN { get; set; }

        #region Validações
        public const string NomeNotNull_Msg = "O nome deve ser preenchido";
        public const string CodigoBACENNotNull_Msg = "O CodigoBACEN deve ser preenchido";

        #endregion
    }


}
