using System.ComponentModel.DataAnnotations;

namespace DataInOrder.Domain.Entities;

public class Person
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Date { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SurName { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public Person(DateTime date, string firstName, string lastName, string surName, string city, string country)
    {
        Date = date;
        FirstName = firstName;
        LastName = lastName;
        SurName = surName;
        City = city;
        Country = country;
    }
}