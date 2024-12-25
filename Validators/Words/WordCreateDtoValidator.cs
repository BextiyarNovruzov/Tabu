using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Tabu.DTOs.Words;

namespace Tabu.Validators.Words
{
    public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
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
            RuleForEach(x => x.BanedWords)
                .MinimumLength(2)
                .WithMessage("BannedWords min 2 herifli ola biler!")
                .NotNull()
                .WithMessage("BannedWords Null ola bilmez!")
                .NotEmpty()
                .WithMessage("BannedWords Empty ola bilmez");
            RuleFor(x => x.BanedWords)
                .NotNull()
                .WithMessage("BannedWords Yaradilmalidir!")
                .NotEmpty()
                .WithMessage("BannedWords Yaradilmalidir!")
                .Must(x=>x.Count == 6)
                .WithMessage("BannedWords sayi 6 olmalidir!");
        }
    }
}
