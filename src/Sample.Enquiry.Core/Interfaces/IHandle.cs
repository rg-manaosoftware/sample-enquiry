using Sample.Enquiry.Core.SharedKernel;

namespace Sample.Enquiry.Core.Interfaces
{
    public interface IHandle<T> where T : BaseDomainEvent
    {
        void Handle(T domainEvent);
    }
}