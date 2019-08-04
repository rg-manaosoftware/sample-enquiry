using System;
using Sample.Enquiry.Core.Events;
using Sample.Enquiry.Core.SharedKernel;
using Sample.Enquiry.Core.Dtos;

namespace Sample.Enquiry.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionDto ToDto()
        {
            var transactionDto = new TransactionDto()
            {
                Id = this.Id,
                Status = this.Status,
                Amount = this.Amount,
                Currency = this.Currency,
                CustomerId = this.CustomerId,
                TransactionDate = this.TransactionDate
            };
            return transactionDto;
        }
    }
}
