using DataInOrder.Domain.Entities;

namespace DataInOrder.Domain.Repositories;

public interface IPesonRepository
{
    Task CreatePersonAsunc(Person person);
    Task<Person> GetById(Guid id);
}