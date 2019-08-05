using Sample.Enquiry.Core.Entities;
using System.Linq;
using Xunit;

namespace Sample.Enquiry.Tests.Integration.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {

        [Fact]
        public void AddCustomerAndSetsId()
        {
            var repository = GetRepository();
            var customer = new CustomerBuilder().Build();

            repository.Add(customer);

            var newCustomer = repository.List<Customer>().FirstOrDefault();

            Assert.Equal(customer, newCustomer);
            Assert.True(newCustomer?.Id > 0);
        }
    }
}
