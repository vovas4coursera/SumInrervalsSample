using FluentValidation;
namespace SumIntervalsSample.BusinessLibrary.Models.Validators;

public class IntervalValidator : AbstractValidator<Interval>
{
    public IntervalValidator()
    {
        RuleFor(x => x.To).GreaterThanOrEqualTo(y => y.From);
    }
}
