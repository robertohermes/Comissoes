using Dufry.Comissoes.Domain.Validation;

namespace Dufry.Comissoes.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}