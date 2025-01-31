using BookShop.ApiCaller.Model;
using FluentValidation;

namespace BookShop.Validators
{
    public class CustomerValidator : AbstractValidator<CustomerRegisterDTO>
    {
        public CustomerValidator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible);
            RuleFor(c => c.Mobile).NotEmpty().Matches("[0-9]{11}", System.Text.RegularExpressions.RegexOptions.None);
            RuleFor(c => c.Tel).NotEmpty().Matches("[0-9]{11}", System.Text.RegularExpressions.RegexOptions.None);
            RuleFor(c => c.NationalCode).NotEmpty().Matches("[0-9]{10}", System.Text.RegularExpressions.RegexOptions.None);
            RuleFor(c => c.Password).NotEmpty().MinimumLength(6);
        }
    }
}
