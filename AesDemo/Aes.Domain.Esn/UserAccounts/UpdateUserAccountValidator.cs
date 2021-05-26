using System;
using System.Collections.Generic;
using System.Text;
using Aes.Data.Esn.UserAccounts.Commands;
using FluentValidation;

namespace Aes.Domain.Esn.UserAccounts
{
    public class UpdateUserAccountValidator : AbstractValidator<UpdateUserAccountCommand>
    {
        public UpdateUserAccountValidator()
        {
            RuleFor(c => c.UserName).NotEmpty()
                .WithErrorCode("1000")
                .WithName("UserName")
                .WithMessage("User name is required.");
            RuleFor(c => c.FirstName).NotEmpty()
                .WithErrorCode("1001")
                .WithName("FirstName")
                .WithMessage("First name is required.");
            RuleFor(c => c.LastName).NotEmpty()
                .WithErrorCode("1002")
                .WithName("LastName")
                .WithMessage("Last name is required.");

        }




    }
}
