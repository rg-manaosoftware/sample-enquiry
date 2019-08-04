using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Infrastructure.Data;

namespace Sample.Enquiry.Api
{
    public static class SeedData
    {
        public static void PopulateTestData(AppDbContext dbContext)
        {
            var toDos = dbContext.ToDoItems;
            foreach (var item in toDos)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.ToDoItems.Add(new ToDoItem()
            {
                Title = "Test Item 1",
                Description = "Test Description One"
            });
            dbContext.ToDoItems.Add(new ToDoItem()
            {
                Title = "Test Item 2",
                Description = "Test Description Two"
            });
            dbContext.SaveChanges();
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
            dbContext.Customers.Add(new Customer()
            {
                Id = 345678,
                Name = "Customer with 2 transactions",
                Email = "user3@domain.com",
                MobileNumber = 3456789012
            });
            dbContext.SaveChanges();
        }

    }
}
