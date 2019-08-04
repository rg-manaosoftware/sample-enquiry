using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sample.Enquiry.Core.Events;
using Sample.Enquiry.Core.SharedKernel;
using Sample.Enquiry.Core.Dtos;

namespace Sample.Enquiry.Core.Entities
{
    public class Customer : BaseEntity
    {
        private List<Transaction> _transactions = new List<Transaction>();

        public string Name { get; set; }
        public string Email { get; set; }
        public ulong MobileNumber { get; set; }
        public IEnumerable<Transaction> Transactions => new Collection<Transaction>(_transactions);

        public void AddEntry(Transaction transaction)
        {
            _transactions.Add(transaction);
            Events.Add(new TransactionAddedEvent(this.Id, transaction));
        }

        public CustomerDto ToDto()
        {
            var customerDto = new CustomerDto()
            {
                Name = this.Name,
                Email = this.Email,
                MobileNumber = this.MobileNumber
            };
            if( this.Transactions.Count() > 0 )
            {
                customerDto.Transactions = this.Transactions.Select( t => t.ToDto()).ToList();
            }
            return customerDto;
        }
    }
}
