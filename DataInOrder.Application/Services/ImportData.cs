using DataInOrder.Domain.Entities;
using DataInOrder.Domain.Repositories;

namespace DataInOrder.Application.Services;

public static class ImportData
{
    public static void ImportPersons(List<Person> persons, IPersonRepository repository)
    {
        if (persons == null || !persons.Any())
            throw new ArgumentException("The list of persons is empty or null.");

        foreach (var person in persons)
        {
            repository.AddRecord(person);
        }

        repository.SaveChanges();
    }
}