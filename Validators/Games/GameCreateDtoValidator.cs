using FluentValidation;
using Tabu.DTOs.Games;

namespace Tabu.Validators.Games
{
    public class GameCreateDtoValidator : AbstractValidator<GameCreateDto>
    {
        public GameCreateDtoValidator()
        {
            RuleFor(x => x.BannedWordCount)
                .NotNull()
                .WithMessage("BannedWordCount Null ola bilmez!")
                .NotEmpty()
                .WithMessage("BannedWordCount empty ola bilemz!")
                .GreaterThan(0)
                .WithMessage("BannedWordCount 0 ve ya menfi ola bilmez!.")
                .LessThanOrEqualTo(15)
                .WithMessage("BannedWordCount yalniz 0 ve 15 arasi secile biler");

            RuleFor(x => x.SkipCount)
                .NotNull()
                .WithMessage("SkipCount Null ola bilmez!")
                .NotEmpty()
                .WithMessage("SkipCount empty ola bilemz!")
                .GreaterThan(0)
                .WithMessage("SkipCount 0 ve ya menfi ola bilmez!.")
                .LessThanOrEqualTo(15)
                .WithMessage("SkipCount yalniz 0 ve 15 arasi secile biler");


            RuleFor(x => x.FailCount)
                .NotNull()
                .WithMessage("FailCount Null ola bilmez!")
                .NotEmpty()
                .WithMessage("FailCount empty ola bilemz!")
                .GreaterThan(0)
                .WithMessage("FailCount 0 ve ya menfi ola bilmez!.")
                .LessThanOrEqualTo(15)
                .WithMessage("FailCount yalniz 0 ve 15 arasi secile biler");
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
