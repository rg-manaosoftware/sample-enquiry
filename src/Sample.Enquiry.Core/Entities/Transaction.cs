using System;
using Sample.Enquiry.Core.Events;
using Sample.Enquiry.Core.SharedKernel;

namespace Sample.Enquiry.Core.Entities
{
    public class Transaction : BaseEntity
    {
        public string Status { get; set; }
        public decimal Amount { get; set; }
        public string Currency { get; private set; }
        public DateTime TransactionDate { get; private set; }
    }
}
