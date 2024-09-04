namespace GenReport.Validations.Onboarding
{
    using FastEndpoints;
    using FluentValidation;
    using FluentValidation.AspNetCore;
    using FluentValidation.Results;
    using GenReport.Infrastructure.Models.HttpRequests.Onboarding;
    using GenReport.Infrastructure.Static.Externsions;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class LoginRequestValidator : Validator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x=>x.Email).NotEmpty().WithMessage("Email is required").Must(x=>x.IsEmail()).WithMessage("Email address is not valid");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required").MinimumLength(8).WithMessage("Password is too short");
        }
    }
}
