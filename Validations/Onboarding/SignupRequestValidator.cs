namespace GenReport.Validations.Onboarding
{
    using FastEndpoints;
    using FluentValidation;
    using GenReport.Infrastructure.Models.HttpRequests.Onboarding;
    using GenReport.Infrastructure.Static.Externsions;

    /// <summary>
    /// Defines the <see cref="SignupRequestValidator" />
    /// </summary>
    public class SignupRequestValidator : Validator<SignupRequest>
    {
        public SignupRequestValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required").Must(x => x.IsEmail()).WithMessage("Email address is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(8).WithMessage("Password is too short");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name is required").MaximumLength(30).WithMessage("First Name is too long");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required").MaximumLength(30).WithMessage("Last Name is too long");
        }
    }
}
