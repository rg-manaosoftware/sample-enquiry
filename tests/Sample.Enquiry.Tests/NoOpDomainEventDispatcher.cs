using Sample.Enquiry.Core.Interfaces;
using Sample.Enquiry.Core.SharedKernel;

namespace Sample.Enquiry.Tests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public void Dispatch(BaseDomainEvent domainEvent) { }
    }
}
