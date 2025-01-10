using DataInOrder.Domain.Entities;

namespace DataInOrder.Domain.Repositories;

public interface IPersonRepository
{
    public void AddRecord(Person person);
    public void AddFilter(string filter);
    public void AddFilter(string filter, string value);
    public void RemoveFilter(string filter);
    public List<Person> GetFilteredPersons();
    public void SaveChanges();
}