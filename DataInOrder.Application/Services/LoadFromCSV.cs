using DataInOrder.Application.Interfaces;
using DataInOrder.Domain.Entities;
using System.Globalization;

namespace DataInOrder.Application.Services;

public class LoadFromCSV : ILoadFromFile
{
    public List<Person> LoadFromFile(string loadPath)
    {
        var persons = new List<Person>();

        if (!File.Exists(loadPath))
            throw new FileNotFoundException($"File not found: {loadPath}");

        var lines = File.ReadAllLines(loadPath);

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            var parts = line.Split(';');

            if (parts.Length != 6)
                throw new FormatException("Invalid CSV format. Each line must have exactly 6 fields.");

            if (!DateTime.TryParse(parts[0], CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
                throw new FormatException($"Invalid date format: {parts[0]}");

            var person = new Person(
                date,
                parts[1],
                parts[2],
                parts[3],
                parts[4],
                parts[5]
            );

            persons.Add(person);
        }

        return persons;
    }
}