using System.Text.RegularExpressions;
using Conference.Contracts.DTO;
using FluentValidation;

namespace Conference.Core.Validators;

public class CreateOrUpdateBeekeeperDtoValidator : AbstractValidator<CreateOrUpdateBeekeeperDto>
{
    public CreateOrUpdateBeekeeperDtoValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Анонимным участникам у нас не рады");
        RuleFor(x => x.City).NotEmpty().WithMessage("Нам важно знать, откуда вы");
        RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Указание email обязательно")
            .Must(x => Regex.IsMatch(x, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")).WithMessage("Это не email");
        RuleFor(x => x.Phone)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Указание номера телефона обязательно")
            .Must(x => Regex.IsMatch(x, @"^\+?(\d[\d-. ]+)?(\([\d-. ]+\))?[\d-. ]+\d$"))
            .WithMessage("Это не номер телефона");
    }
}