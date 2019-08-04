using System;
using FluentValidation;

namespace Sample.Enquiry.Core.Query
{
    public class QueryParameters
    {
        public string CustomerId { get; set; }
        public string Email { get; set; }

    }

    public class QueryParameterValidator : AbstractValidator<QueryParameters> {
        public QueryParameterValidator() {
            RuleFor(x => x.CustomerId).Matches("^\\d{0,10}$")
                .WithMessage("Invalid Customer Id");
            RuleFor(x => x.Email).EmailAddress()
                .WithMessage("Invalid Email");
            RuleFor(x => x.CustomerId).NotNull().When(x => x.Email == null)
                .WithMessage("No inquiry criteria");
        }
    }
}