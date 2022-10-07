using FluentValidation;
using OnlyFunds._1___Models.Requests;

namespace OnlyFunds._3___Validators;

public class CreateChannelRequestValidator : Validator<CreateChannelRequest>
{
    public CreateChannelRequestValidator()
    {
        RuleFor(x => x.Age)
            .NotEmpty()
            .WithMessage("Age is missing")
            .GreaterThan(0)
            .WithMessage("Age should be greater than 0!");
        
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("your name is required!")
            .MinimumLength(1)
            .WithMessage("your name is too short!");
        
        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("your name is required!")
            .MinimumLength(1)
            .WithMessage("your name is too short!");
    }
}