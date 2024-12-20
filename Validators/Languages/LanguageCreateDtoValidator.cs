using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validators.Languages
{
	public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
	{
		public LanguageCreateDtoValidator()
		{
			RuleFor(x => x.Code)
				.NotEmpty()
				.WithMessage("Code Bos ola bilmz!")
				.NotNull()
				.WithMessage("Code Null ola bilmez")
				.MaximumLength(2)
				.WithMessage("Code 2 simvoldan cox ola bilmez");

			RuleFor(x => x.Name)
				.NotEmpty()
				.WithMessage("Name empty ola bilmez!")
				.NotNull()
				.WithMessage("Name Null ola bilmez!")
				.MaximumLength(32)
				.WithMessage("Name ucun MaxLength 32 dir..)");

			RuleFor(x => x.IconUrl)
				.Matches("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?")
				.WithMessage("Url Linki olmalidir!")
				.NotEmpty()
				.WithMessage("Icon Empty Ola bimez!")
				.NotNull()
				.WithMessage("Icon Null ola bilmez!")
				.MaximumLength(32)
				.WithMessage("Icon ucun MaxLength 512 dir...)");

		}
	}
}
