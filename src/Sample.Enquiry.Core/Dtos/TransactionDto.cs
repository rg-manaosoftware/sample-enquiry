using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sample.Enquiry.Core.Dtos
{
    public class TransactionDto
    {
        public ulong Id { get; set; }
        public string Status { get; set; }
        [DisplayFormat(DataFormatString = "{0:#,##0.00}")]
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public ulong CustomerId { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime TransactionDate { get; set; }
    }
}
