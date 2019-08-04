using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Core.SharedKernel;

namespace Sample.Enquiry.Core.Events
{
public class TransactionAddedEvent : BaseDomainEvent
    {
        public TransactionAddedEvent(ulong customerId, Transaction transaction)
        {
            CustomerId = customerId;
            Transaction = transaction;
        }

        public ulong CustomerId { get; }
        public Transaction Transaction { get; }
    }
}