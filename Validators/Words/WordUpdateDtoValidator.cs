using FluentValidation;
using Tabu.DTOs.Words;

namespace Tabu.Validators.Words
{
    public class WordUpdateDtoValidator : AbstractValidator<WordUpdateDto>
    {
        public WordUpdateDtoValidator()
        {
            RuleFor(x => x.Text)
               .NotEmpty()
               .WithMessage("Text Empty ola bilmez!")
               .NotNull()
               .WithMessage("Text Null ola bilmez")
               .MaximumLength(32)
               .WithMessage("Text length 32-den cox ola bilmez!");
            RuleFor(x => x.LanguageCode)
                .NotEmpty()
                .WithMessage("LanguageCode empty ola bilmez!")
                .NotEmpty()
                .WithMessage("LanguageCode Null ola bilmez!")
                .MaximumLength(2)
                .WithMessage("LanguageCode 2 simvoldan cox ola bilmez!");

        }
    }
}
