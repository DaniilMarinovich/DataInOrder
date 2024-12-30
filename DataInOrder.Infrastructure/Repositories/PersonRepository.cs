using DataInOrder.Domain.Entities;
using DataInOrder.Domain.Repositories;
using DataInOrder.Infrastructure.DBContexts;

namespace DataInOrder.Infrastructure.Repositories
{
    public class PersonRepository: IPesonRepository
    {
        readonly PersonContext  _context;

        public Task CreatePersonAsunc(Person personInfo)
        {
            return Task.CompletedTask;
        }

        public Task<Person> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
