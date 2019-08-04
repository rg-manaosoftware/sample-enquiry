using Ardalis.GuardClauses;
using Sample.Enquiry.Core.Events;
using Sample.Enquiry.Core.Interfaces;

namespace Sample.Enquiry.Core.Services
{
    public class ToDoItemService : IHandle<ToDoItemCompletedEvent>
    {
        public void Handle(ToDoItemCompletedEvent domainEvent)
        {
            Guard.Against.Null(domainEvent, nameof(domainEvent));

            // Do Nothing
        }
    }
}
