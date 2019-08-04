using Sample.Enquiry.Core.SharedKernel;

namespace Sample.Enquiry.Core.Interfaces
{
    public interface IDomainEventDispatcher
    {
        void Dispatch(BaseDomainEvent domainEvent);
    }
}