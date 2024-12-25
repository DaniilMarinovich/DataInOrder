namespace DataInOrder.Domain.Entities;

public class PersonInfo(DateTime date, string firstName, string lastName, string surName, string city, string country)
{
    private readonly Guid Id = Guid.NewGuid();
    public DateTime Date { get; set; } = date;
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public string SurName { get; set; } = surName;
    public string City { get; set; } = city;
    public string Country { get; set; } = country;
}
