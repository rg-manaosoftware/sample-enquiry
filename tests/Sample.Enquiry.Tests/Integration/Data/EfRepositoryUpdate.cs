using Sample.Enquiry.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Sample.Enquiry.Tests.Integration.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public void UpdatesCustomerAfterAddingIt()
        {
            // add an Customer
            var repository = GetRepository();
            var initialTitle = Guid.NewGuid().ToString();
            var Customer = new CustomerBuilder().Name(initialTitle).Build();

            repository.Add(Customer);

            // detach the Customer so we get a different instance
            _dbContext.Entry(Customer).State = EntityState.Detached;

            // fetch the Customer and update its title
            var newCustomer = repository.List<Customer>()
                .FirstOrDefault(i => i.Name == initialTitle);
            Assert.NotNull(newCustomer);
            Assert.NotSame(Customer, newCustomer);
            var newName = Guid.NewGuid().ToString();
            newCustomer.Name = newName;

            // Update the Customer
            repository.Update(newCustomer);
            var updatedCustomer = repository.List<Customer>()
                .FirstOrDefault(i => i.Name == newName);

            Assert.NotNull(updatedCustomer);
            Assert.NotEqual(Customer.Name, updatedCustomer.Name);
            Assert.Equal(newCustomer.Id, updatedCustomer.Id);
        }
    }
}
