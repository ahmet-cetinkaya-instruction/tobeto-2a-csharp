using FluentValidation;
using FluentValidation.Results;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation;

public static class ValidationTool
{
    public static void Validate(IValidator validator, object objectToValidate)
    {
        ValidationContext<object> context = new(objectToValidate); // İlgili nesneyi validate etmek için tanımlıyoruz
        ValidationResult result = validator.Validate(context); // İlgili validator ile ilgili nesneyi validate ediyoruz

        if (!result.IsValid)
            throw new ValidationException(result.Errors);
    }
}
