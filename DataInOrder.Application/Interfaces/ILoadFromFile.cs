using DataInOrder.Domain.Entities;

namespace DataInOrder.Application.Interfaces;

public interface ILoadFromFile
{
    List<Person> LoadFromFile(string loadPath);
}
