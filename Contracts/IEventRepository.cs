using Entities.Model;

namespace Contracts
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents(bool trackChanges);
        Event GetEvent(Guid eventId, bool trackChanges);
        void CreateEvent(Event ev);
        void UpdateEvent(Event ev, bool trackChanges);
        void DeleteEvent(Event ev);
    }
}
