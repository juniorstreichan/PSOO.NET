using FluentValidation;
using PSOO.Domain.Interfaces.Cadastro;

namespace PSOO.Domain.Entity.Cadastro
{
    public class Cliente : BaseClass
    {
        public virtual int ClienteId { get; set; }
        public virtual string Nome { get; set; }
        public virtual string NomeFantasia { get; set; }
        public virtual string CNPJ { get; set; }

        #region Validações

        public const int NomeMaxLength = 100;
        public const string NomeNotNull_Msg = "O nome deve ser preenchido";
        public const string NomeMaxLength_Msg = "O nome deve ter entre 3 e 100 caracteres";

        public const int NomeFantasiaMaxLength = 100;
        public const string NomeFantasiaNotNull_Msg = "O nome fantasia deve ser preenchido";
        public const string NomeFantasiaMaxLength_Msg = "O nome fantasia deve ter entre 3 e 100 caracteres";

        public const int CNPJMaxLength = 20;
        public const string CNPJNotNull_Msg = "O CNPJ deve ser preenchido";
        public const string CNPJMaxLength_Msg = "O CNPJ deve ter até 20 caracteres";

        #endregion Validações
    }

    public class ClienteValidator : AbstractValidator<Cliente>, IClienteValidator
    {
        private IClienteService _clienteService;

        public ClienteValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            RuleFor(x => x.ClienteId).NotNull();

            RuleFor(x => x.Nome).NotNull().WithMessage(Cliente.NomeNotNull_Msg);
            RuleFor(x => x.Nome).Length(3, Cliente.NomeMaxLength).WithMessage(Cliente.NomeMaxLength_Msg);
            RuleFor(x => x.NomeFantasia).NotNull().WithMessage(Cliente.NomeFantasiaNotNull_Msg);
            RuleFor(x => x.NomeFantasia).Length(3, Cliente.NomeFantasiaMaxLength).WithMessage(Cliente.NomeFantasiaMaxLength_Msg);
            RuleFor(x => x.CNPJ).NotNull().WithMessage(Cliente.CNPJNotNull_Msg);
            RuleFor(x => x.CNPJ).Length(3, Cliente.CNPJMaxLength).WithMessage(Cliente.CNPJMaxLength_Msg);
        }

        public void SetService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
    }
}

