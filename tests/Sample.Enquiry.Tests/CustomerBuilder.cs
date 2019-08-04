using Sample.Enquiry.Core.Entities;

namespace Sample.Enquiry.Tests
{
    public class CustomerBuilder
    {
        private Customer _customer = new Customer();

        public CustomerBuilder Id(int id)
        {
            _customer.Id = id;
            return this;
        }

        public CustomerBuilder Name(string name)
        {
            _customer.Name = name;
            return this;
        }

        public CustomerBuilder Email(string email)
        {
            _customer.Email = email;
            return this;
        }

        public CustomerBuilder MobileNumber(int mobileNumber)
        {
            _customer.MobileNumber = mobileNumber;
            return this;
        }

        public CustomerBuilder WithDefaultValues()
        {
            _customer = new Customer() { Id = 123456, Name = "FirstName LastName", Email = "user@domain.com", MobileNumber = 0123456789 };

            return this;
        }

        public Customer Build() => _customer;
    }
}
