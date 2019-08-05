using System.Linq;
using Sample.Enquiry.Core.Query;
using Xunit;


namespace Sample.Enquiry.Tests.Core.Entities
{
    public class QueryParametersValidate
    {
        private QueryParameterValidator _validator;
        public QueryParametersValidate()
        {
            _validator = new QueryParameterValidator();
        }
        [Fact]
        public void No_Enquiry_Params_Failed()
        {
            var query = new QueryParameters();
            var result = _validator.Validate(query);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            var errorMessage = result.Errors.First();
            Assert.Equal("No inquiry criteria", errorMessage.ErrorMessage);
        }
        [Fact]
        public void Corect_CustomerId_Valid()
        {
            var query = new QueryParameters()
            {
                CustomerId = "1234567890"
            };
            var result = _validator.Validate(query);
            Assert.True(result.IsValid);
        }
        [Fact]
        public void Invalid_CustomerId_Failed()
        {
            var query = new QueryParameters()
            {
                CustomerId = "12345678901"
            };
            var result = _validator.Validate(query);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            var errorMessage = result.Errors.First();
            Assert.Equal("Invalid Customer Id", errorMessage.ErrorMessage);
        }
        [Fact]
        public void Corect_Email_Valid()
        {
            var query = new QueryParameters()
            {
                Email = "test@google.com"
            };
            var result = _validator.Validate(query);
            Assert.True(result.IsValid);
        }
        [Fact]
        public void Invalid_Email_Failed()
        {
            var query = new QueryParameters()
            {
                Email = "unknown"
            };
            var result = _validator.Validate(query);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            var errorMessage = result.Errors.First();
            Assert.Equal("Invalid Email", errorMessage.ErrorMessage);
        }
        [Fact]
        public void Corect_Customer_And_Email_Valid()
        {
            var query = new QueryParameters()
            {
                CustomerId = "1234567890",
                Email = "test@google.com"
            };
            var result = _validator.Validate(query);
            Assert.True(result.IsValid);
        }
        [Fact]
        public void Invalid_Customer_And_Email_Failed()
        {
            var query = new QueryParameters()
            {
                CustomerId = "12345678901",
                Email = "unknown"
            };
            var result = _validator.Validate(query);
            Assert.False(result.IsValid);
            Assert.Equal(2, result.Errors.Count);
            var firstError = result.Errors.First();
            Assert.Equal("Invalid Customer Id", firstError.ErrorMessage);
            var anotherError = result.Errors.Last();
            Assert.Equal("Invalid Email", anotherError.ErrorMessage);
        }
        [Fact]
        public void Invalid_Customer_With_Valid_Email_Failed()
        {
            var query = new QueryParameters()
            {
                CustomerId = "12345678901",
                Email = "test@domain.com"
            };
            var result = _validator.Validate(query);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            var errorMessage = result.Errors.First();
            Assert.Equal("Invalid Customer Id", errorMessage.ErrorMessage);
        }
        [Fact]
        public void Invalid_Email_With_Valid_Customer_Failed()
        {
            var query = new QueryParameters()
            {
                CustomerId = "123456",
                Email = "unknown"
            };
            var result = _validator.Validate(query);
            Assert.False(result.IsValid);
            Assert.Single(result.Errors);
            var errorMessage = result.Errors.First();
            Assert.Equal("Invalid Email", errorMessage.ErrorMessage);
        }
    }
}
