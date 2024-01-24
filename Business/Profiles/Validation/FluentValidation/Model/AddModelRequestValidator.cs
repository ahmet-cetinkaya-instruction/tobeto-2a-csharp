using Business.Requests.Model;
using FluentValidation;

namespace Business.Profiles.Validation.FluentValidation.Model;

public class AddModelRequestValidator : AbstractValidator<AddModelRequest>
{
    public AddModelRequestValidator()
    {
        RuleFor(x => x.BrandId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.FuelId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.TransmissionId).NotEmpty().GreaterThan(0);
        RuleFor(x => x.Name).NotEmpty().MinimumLength(2).MaximumLength(50);
        RuleFor(x => x.Year).NotEmpty().GreaterThan((short)0);
        RuleFor(x => x.DailyPrice).NotEmpty().GreaterThan(0);

        //RuleFor(model=> model.Name).Must(StartsWithA);
    }

    //private bool StartsWithA(string arg)
    //{
    //    return arg.StartsWith("A");
    //}
}
