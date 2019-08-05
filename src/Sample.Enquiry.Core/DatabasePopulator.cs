using System;
using System.Linq;
using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Core.Interfaces;

namespace Sample.Enquiry.Core
{
    public static class DatabasePopulator
    {
        public static int PopulateDatabase(IRepository repository)
        {
            if(repository.List<Customer>().Any()) return 0;


            repository.Add(new Customer()
            {
                Id = 123456,
                Name = "Customer without transaction",
                Email = "user1@domain.com",
                MobileNumber = 1234567890
            });
            repository.Add(new Customer()
            {
                Id = 234567,
                Name = "Customer with 1 transaction",
                Email = "user2@domain.com",
                MobileNumber = 2345678901
            });
            repository.Add(new Customer()
            {
                Id = 345678,
                Name = "Customer with 2 transactions",
                Email = "user3@domain.com",
                MobileNumber = 3456789012
            });
            repository.Add(new Transaction()
            {
                Id = 1,
                CustomerId = 234567,
                Amount = 20,
                Status = "Success",
                Currency = "USD",
                TransactionDate = DateTime.Now
            });
            repository.Add(new Transaction()
            {
                Id = 2,
                CustomerId = 345678,
                Amount = 12.34M,
                Status = "Success",
                Currency = "THB",
                TransactionDate = DateTime.Now
            });
            repository.Add(new Transaction()
            {
                Id = 3,
                CustomerId = 345678,
                Amount = 50.0M,
                Status = "Success",
                Currency = "USD",
                TransactionDate = DateTime.Now.AddMonths(-1)
            });
            return repository.List<Customer>().Count;
        }
    }
}
