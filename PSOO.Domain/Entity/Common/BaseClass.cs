

using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;

public abstract class BaseClass
{
    public virtual bool IsValid { get; protected set; }
    public virtual ValidationResult ValidationResult { get; set; }

    public virtual void Validate(IValidator validator)
    {
        if (validator != null)
        {
            ValidationResult = validator.Validate(this);
            IsValid = ValidationResult.IsValid;
        }
    }

    public virtual List<KeyValuePair<string, string>> GetValidationsList()
    {
        var lista = new List<KeyValuePair<string, string>>();

        var erros = ValidationResult.Errors;
        foreach (var erro in erros)
        {
            var key = erro.PropertyName;
            var value = erro.ErrorMessage;
            var pair = new KeyValuePair<string, string>(key, value);
            lista.Add(pair);
        }

        return lista;
    }
}