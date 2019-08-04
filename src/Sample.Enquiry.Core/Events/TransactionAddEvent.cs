using Sample.Enquiry.Core.Entities;
using Sample.Enquiry.Core.SharedKernel;

namespace Sample.Enquiry.Core.Events
{
public class TransactionAddedEvent : BaseDomainEvent
    {
        public TransactionAddedEvent(int customerId, Transaction transaction)
        {
            CustomerId = customerId;
            Transaction = transaction;
        }

        public int CustomerId { get; }
        public Transaction Transaction { get; }
    }
}