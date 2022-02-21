using Conference.Contracts.DTO;
using FluentValidation;

namespace Conference.Core.Validators;

public class CreateOrUpdateEventDtoValidator : AbstractValidator<CreateOrUpdateEventDto>
{
    public CreateOrUpdateEventDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("У события должно быть название");
        RuleFor(x => x.Time).NotEmpty().WithMessage("У события должно быть указано время");
        RuleFor(x => x.SpeakerName).NotEmpty().WithMessage("Указание спикера обязательно");
        RuleFor(x => x.SpeakerLocation).NotEmpty().WithMessage("Происхождение спикера обязательно");
    }
}