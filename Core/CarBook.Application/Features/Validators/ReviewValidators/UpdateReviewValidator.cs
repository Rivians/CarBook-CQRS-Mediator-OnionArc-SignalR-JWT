using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Validators.ReviewValidators
{
	public class UpdateReviewValidator : AbstractValidator<UpdateReviewCommand>
	{
        public UpdateReviewValidator()
        {
			RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz.");
			RuleFor(x => x.CustomerName).MinimumLength(3).WithMessage("Lütfen en az 3 karakterden oluşan bir veri girişi yapınız");
			RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz");
			RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorumu boş geçmeyiniz");
			RuleFor(x => x.Comment).MinimumLength(10).WithMessage("Lütfen en az 10 karakterden oluşan bir veri girişi yapınız");
			RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen en fazla 500 karakterden oluşan bir veri girişi yapınız");

		}
    }
}
