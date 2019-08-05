using System;
using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Infrastructure.Data;

namespace Sample.Enquiry.Api
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            //customer
            var customers = dbContext.Customers;
            foreach (var customer in customers)
            {
                dbContext.Remove(customer);
                dbContext.SaveChanges();
            }
            dbContext.Customers.Add(new Customer()
            {
                Id = 123456,
                Name = "Customer without transaction",
                Email = "user1@domain.com",
                MobileNumber = 1234567890
            });
            dbContext.Customers.Add(new Customer()
            {
                Id = 234567,
                Name = "Customer with 1 transaction",
                Email = "user2@domain.com",
                MobileNumber = 2345678901
            });
            // 1 transaction
            dbContext.Transactions.Add(new Transaction()
            {
                Id = 1,
                CustomerId = 234567,
                Amount = 20,
                Status = "Success",
                Currency= "USD",
                TransactionDate = DateTime.Now
            });
            dbContext.Customers.Add(new Customer()
            {
                Id = 345678,
                Name = "Customer with 2 transactions",
                Email = "user3@domain.com",
                MobileNumber = 3456789012
            });
            dbContext.Transactions.Add(new Transaction()
            {
                Id = 2,
                CustomerId = 345678,
                Amount = 12.34M,
                Status = "Success",
                Currency = "THB",
                TransactionDate = DateTime.Now
            });
            dbContext.Transactions.Add(new Transaction()
            {
                Id = 3,
                CustomerId = 345678,
                Amount = 50.0M,
                Status = "Success",
                Currency = "USD",
                TransactionDate = DateTime.Now.AddMonths(-1)
            });
            dbContext.SaveChanges();
        }

    }
}
