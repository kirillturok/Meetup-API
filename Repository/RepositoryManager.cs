using Contracts;
using Entities;

namespace Repository
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private IEventRepository _eventRepository;

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }

        public IEventRepository Event
        {
            get
            {
                _eventRepository ??= new EventRepository(_repositoryContext);
                return _eventRepository;
            }
        }

        public void Save() => _repositoryContext.SaveChanges();
    }
}
