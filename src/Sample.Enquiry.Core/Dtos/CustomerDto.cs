using System.Collections.Generic;
using System.Collections.ObjectModel;
using Sample.Enquiry.Core.Events;
using Sample.Enquiry.Core.SharedKernel;

namespace Sample.Enquiry.Core.Dtos
{
    public class CustomerDto
    {
        private List<TransactionDto> _transactions = new List<TransactionDto>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int MobileNumber { get; set; }
        public List<TransactionDto> Transactions
        {
            get
            {
                return _transactions;
            }
            set
            {
                _transactions = value;
            }
        }
    }
}
