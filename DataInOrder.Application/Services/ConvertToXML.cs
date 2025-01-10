using DataInOrder.Application.Interfaces;
using DataInOrder.Domain.Entities;
using System.Xml.Linq;


namespace DataInOrder.Application.Services;

public class ConvertToXML : IConvert
{
    public void Convert(List<Person> persons, string fullPath)
    {
        XDocument xdoc = new XDocument();
        XElement personsXML = new XElement("Persons");

    
        foreach (Person person in persons)
        {
            XElement tempPerson = new XElement("Person",
                new XAttribute("id", person.Id),
                new XElement("Date", person.Date),
                new XElement("FirstName", person.FirstName),
                new XElement("LastName", person.LastName),
                new XElement("SurName", person.SurName),
                new XElement("City", person.City),
                new XElement("Country", person.Country));

            personsXML.Add(tempPerson);
        }

        xdoc.Add(personsXML);
        xdoc.Save(fullPath);
    }
}
