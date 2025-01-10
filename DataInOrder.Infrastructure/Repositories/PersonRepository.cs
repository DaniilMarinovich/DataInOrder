using DataInOrder.Domain.Entities;
using DataInOrder.Domain.Repositories;
using DataInOrder.Infrastructure.DBContexts;

namespace DataInOrder.Infrastructure.Repositories
{
    public class PersonRepository: IPersonRepository
    {
        readonly PersonContext _context;
        private Dictionary<string, string> filters;
        private IQueryable<Person> query;

        PersonRepository(PersonContext context)
        {
            _context = context;
            filters = [];
            query = context.Persons;
        }

        public void AddRecord(Person person)
        {
            _context.Persons.Add(person);
        }

        public void AddFilter(string filter)
        {
            filters.Add(filter, string.Empty);
        }

        public void AddFilter(string filter, string value)
        {
            filters.Add(filter, value);
        }

        public void RemoveFilter(string filter)
        {
            filters.Remove(filter);
        }

        private IQueryable<Person> ApplyFilters()
        {
            ClearQuery();

            foreach (var filter in filters.Keys)
            {
                switch (filter)
                {
                    case "DateAsc":
                        query = query.OrderBy(p => p.Date);
                        break;
                    case "FirstNameAsc":
                        query = query.OrderBy(p => p.FirstName);
                        break;
                    case "LastNameAsc":
                        query = query.OrderBy(p => p.LastName);
                        break;
                    case "SurNameAsc":
                        query = query.OrderBy(p => p.SurName);
                        break;
                    case "CityAsc":
                        query = query.OrderBy(p => p.City);
                        break;
                    case "CountryAsc":
                        query = query.OrderBy(p => p.Country);
                        break;
                    case "DateDesc":
                        query = query.OrderByDescending(p => p.Date);
                        break;
                    case "FirstNameDesc":
                        query = query.OrderByDescending(p => p.FirstName);
                        break;
                    case "LastNameDesc":
                        query = query.OrderByDescending(p => p.LastName);
                        break;
                    case "SurNameDesc":
                        query = query.OrderByDescending(p => p.SurName);
                        break;
                    case "CityDesc":
                        query = query.OrderByDescending(p => p.City);
                        break;
                    case "CountryDesc":
                        query = query.OrderByDescending(p => p.Country);
                        break;
                    case "DateSearch":
                        query = query.Where(p => p.Date == DateTime.Parse(filters[filter]));
                        break;
                    case "FirstNameSearch":
                        query = query.Where(p => p.FirstName == filters[filter]);
                        break;
                    case "LastNameSearch":
                        query = query.Where(p => p.LastName == filters[filter]);
                        break;
                    case "SurNameSearch":
                        query = query.Where(p => p.SurName == filters[filter]);
                        break;
                    case "CitySearch":
                        query = query.Where(p => p.City == filters[filter]);
                        break;
                    case "CountrySearch":
                        query = query.Where(p => p.Country == filters[filter]);
                        break;
                }
            }

            return query.AsQueryable();
        }

        private void ClearQuery()
        {
            query = _context.Persons;
        }

        public List<Person> GetFilteredPersons()
        {
            return [.. ApplyFilters()];
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}