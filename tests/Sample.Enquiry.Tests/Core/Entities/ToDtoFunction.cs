using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Core.Dtos;
using Xunit;


namespace Sample.Enquiry.Tests.Core.Entities
{
    public class ToDtoFunctionTest
    {
        private Customer _customer;
        public ToDtoFunctionTest()
        {
            _customer = new Customer()
            {
                Id = 123456,
                Name = "Customer without transaction",
                Email = "user1@domain.com",
                MobileNumber = 1234567890,
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {
                        Id = 1,
                        CustomerId = 234567,
                        Amount = 20,
                        Status = "Success",
                        Currency = "USD",
                        TransactionDate = DateTime.Now
                    }
                }
            };
        }
        [Fact]
        public void CustomerToDto_Is_Correct()
        {
            var customerDto = _customer.ToDto();
            Assert.IsType<CustomerDto>(customerDto);
        }
        [Fact]
        public void TransactionToDto_Is_Correct()
        {
            var transactionDto = _customer.Transactions.First().ToDto();
            Assert.IsType<TransactionDto>(transactionDto);
        }
        [Fact]
        public void TransactionToDto_Is_Correct_format()
        {
            var transactionDto = _customer.Transactions.First().ToDto();
            Assert.IsType<TransactionDto>(transactionDto);
            var transactionDate = DateTime.ParseExact(transactionDto.TransactionDate, "dd/MM/yy hh:mm", CultureInfo.InvariantCulture);
            Assert.IsType<DateTime>(transactionDate);
            Assert.Matches("^[0-9]*(\\.[0-9]{1,2})?$", transactionDto.Amount);
        }

        [Fact]
        public void CustomerToDto_Transaction_Is_Exist()
        {
            var customerDto = _customer.ToDto();
            Assert.IsType<CustomerDto>(customerDto);
            Assert.Single(customerDto.Transactions);
        }
    }
}
