using FluentValidation;
using PSOO.Domain.Interfaces.Cadastro;

namespace PSOO.Domain.Entity.Cadastro
{
    public class Municipio : BaseClass
    {
        public virtual int MunicipioId { get; set; }
        public virtual string Nome { get; set; }
        public virtual string CodigoIBGE { get; set; }
        public virtual string SiglaUf { get; set; }
        public virtual string CodigoIBGEUF { get; set; }
        public virtual string NomePais { get; set; }
        public virtual string CodigoPaisBACEN { get; set; }



        #region Validações

        public const int NomeMaxLength = 50;
        public const string NomeNotNull_Msg = "O nome deve ser preenchido";
        public const string NomeMaxLength_Msg = "O nome deve ter até 50 caracteres";

        public const int CodigoIBGEMaxLength = 20;
        public const string CodigoIBGENotNull_Msg = "CodigoIBGE deve ser preenchido";
        public const string CodigoIBGEMaxLength_Msg = "CodigoIBGE deve ter até 20 caracteres";

        public const int SiglaUFMaxLength = 2;
        public const string SiglaUFNotNull_Msg = "SiglaUF deve ser preenchido";
        public const string SiglaUFMaxLength_Msg = "SiglaUF deve ter  2 caracteres";

        public const int CodigoIBGEUFMaxLength = 50;
        public const string CodigoIBGEUFNotNull_Msg = "CodigoIBGEUF deve ser preenchido";
        public const string CodigoIBGEUFMaxLength_Msg = "CodigoIBGEUF deve ter até 50 caracteres";

        public const int NomePaisMaxLength = 50;
        public const string NomePaisNotNull_Msg = "NomePais deve ser preenchido";
        public const string NomePaisMaxLength_Msg = "NomePais deve ter até 50 caracteres";


        #endregion Validações
    }

    public class MunicipioValidator : AbstractValidator<Municipio>, IMunicipioValidator
    {
        private IMunicipioService _municipioService;

        public MunicipioValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.MunicipioId).NotNull();

            RuleFor(x => x.Nome).NotNull().WithMessage(Municipio.NomeNotNull_Msg);
            RuleFor(x => x.Nome).Length(3, Municipio.NomeMaxLength).WithMessage(Municipio.NomeMaxLength_Msg);

            RuleFor(x => x.CodigoIBGE).NotNull().WithMessage(Municipio.CodigoIBGENotNull_Msg);
            RuleFor(x => x.CodigoIBGE).Length(3, Municipio.CodigoIBGEMaxLength).WithMessage(Municipio.CodigoIBGEMaxLength_Msg);

            RuleFor(x => x.SiglaUf).NotNull().WithMessage(Municipio.SiglaUFNotNull_Msg);
            RuleFor(x => x.SiglaUf).Length(3, Municipio.SiglaUFMaxLength).WithMessage(Municipio.SiglaUFMaxLength_Msg);

            RuleFor(x => x.CodigoIBGEUF).NotNull().WithMessage(Municipio.CodigoIBGEUFNotNull_Msg);
            RuleFor(x => x.CodigoIBGEUF).Length(3, Municipio.CodigoIBGEUFMaxLength).WithMessage(Municipio.CodigoIBGEUFMaxLength_Msg);

            RuleFor(x => x.NomePais).NotNull().WithMessage(Municipio.NomePaisNotNull_Msg);
            RuleFor(x => x.NomePais).Length(3, Municipio.NomePaisMaxLength).WithMessage(Municipio.NomePaisMaxLength_Msg);

        }

        public void SetService(IMunicipioService MunicipioService)
        {
            _municipioService = MunicipioService;
        }
    }
}

