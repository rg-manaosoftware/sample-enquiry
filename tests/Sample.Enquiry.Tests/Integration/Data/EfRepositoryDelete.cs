using Sample.Enquiry.Core.Entities;
using System;
using Xunit;

namespace Sample.Enquiry.Tests.Integration.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public void DeletesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var customer = new CustomerBuilder().Name(initialName).Build();
            repository.Add(customer);

            // delete the item
            repository.Delete(customer);

            // verify it's no longer there
            Assert.DoesNotContain(repository.List<Customer>(),
                i => i.Name == initialName);
        }
    }
}
