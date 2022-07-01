using Contracts;
using Entities;
using Entities.Model;

namespace Repository
{
    public class EventRepository : RepositoryBase<Event>, IEventRepository
    {
        public EventRepository(RepositoryContext repositoryContext) : base(repositoryContext) { }

        public IEnumerable<Event> GetAllEvents(bool trackChanges)
            => FindAll(trackChanges)
                .OrderBy(c => c.Name).ToList();

        public Event GetEvent(Guid eventId, bool trackChanges) 
        => FindByCondition(c => c.Id.Equals(eventId), trackChanges).SingleOrDefault();

        public void CreateEvent(Event ev)
        {
            Create(ev);
        }

        public void UpdateEvent(Event ev, bool trackChanges)
        {
            Update(ev);
        }

        public void DeleteEvent(Event ev)
        {
            Delete(ev);
        }
    }
}
