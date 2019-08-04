using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sample.Enquiry.Core.Events;
using Sample.Enquiry.Core.SharedKernel;

namespace Sample.Enquiry.Core.Entities
{
    public class Customer : BaseEntity
    {
        private readonly List<Transaction> _transactions = new List<Transaction>();

        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public IEnumerable<Transaction> Transactions => new ReadOnlyCollection<Transaction>(_transactions);

        public void AddEntry(Transaction transaction)
        {
            _transactions.Add(transaction);
            Events.Add(new TransactionAddedEvent(this.Id, transaction));
        }
    }
}
