using FluentValidation;
using Tabu.DTOs.BannedWords;

namespace Tabu.Validators.BannedWords
{
    public class BannedWordCreateDtoValidator : AbstractValidator<BannedWordCreateDto>
    {
        public BannedWordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Text Empty ola bilmez!")
                .NotNull()
                .WithMessage("Text Null ola bilmez")
                .MaximumLength(32)
                .WithMessage("Text length 32-den cox ola bilmez!");
            RuleFor(x => x.WordId)
                .GreaterThan(0)
                 .WithMessage("WordId 0 ve ya menfi ola bilmez!.");


        }
    }
}
