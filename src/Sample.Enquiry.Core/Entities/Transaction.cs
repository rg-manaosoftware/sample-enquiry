using System;
using System.ComponentModel.DataAnnotations.Schema;
using Sample.Enquiry.Core.SharedKernel;
using Sample.Enquiry.Core.Dtos;

namespace Sample.Enquiry.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public string Status { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public ulong CustomerId { get; set; }
        public DateTime TransactionDate { get; set; }
        public TransactionDto ToDto()
        {
            var transactionDto = new TransactionDto()
            {
                Id = this.Id,
                Status = this.Status,
                Amount = this.Amount.ToString("#,##0.00"),
                Currency = this.Currency,
                CustomerId = this.CustomerId,
                TransactionDate = this.TransactionDate.ToString("dd/MM/yy HH:mm")
            };
            return transactionDto;
        }
    }
}
