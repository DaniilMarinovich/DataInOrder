using DataInOrder.Domain.Repositories;

namespace DataInOrder.Application.Services;

public class PersonService
{
    private readonly IPersonRepository _personRepository;

    PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }
}
