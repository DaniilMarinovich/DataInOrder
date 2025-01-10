using DataInOrder.Domain.Entities;

namespace DataInOrder.Application.Interfaces;

public interface IConvert
{
    void Convert(List<Person> persons, string fullPath);
}
