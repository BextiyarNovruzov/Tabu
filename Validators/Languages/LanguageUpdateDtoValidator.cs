using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validators.Languages
{
    public class LanguageUpdateDtoValidator : AbstractValidator<LanguageUpdateDto>
    {
        public LanguageUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Ad Empty Ola bilmez!")
                .NotNull()
                .WithMessage("Ad Null ola bilmez!")
                .MaximumLength(32)
                .WithMessage("Adin uzunlugu 32 den cox ola bilmez!");
            RuleFor(x => x.Icon)
                 .Matches("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?")
                 .WithMessage("Url Linki olmalidir!")
                 .NotEmpty()
                 .WithMessage("Icon Empty Ola bimez!")
                 .NotNull()
                 .WithMessage("Icon Null ola bilmez!")
                 .MaximumLength(512)
                 .WithMessage("Icon ucun MaxLength 512 dir...)");
        }
    }
}
