using System;
using FluentValidation;

namespace Sample.Enquiry.Core.Query
{
    public static class QueryParametersExtensions
    {
        public static bool HasIdQuery(this QueryParameters queryParameters)
        {
            return !String.IsNullOrEmpty(queryParameters.CustomerId);
        }
        public static bool HasEmailQuery(this QueryParameters queryParameters)
        {
            return !String.IsNullOrEmpty(queryParameters.Email);
        }

    }
}