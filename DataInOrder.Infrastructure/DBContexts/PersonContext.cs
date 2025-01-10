using Microsoft.EntityFrameworkCore;
using DataInOrder.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace DataInOrder.Infrastructure.DBContexts;

public class PersonContext: DbContext
{
    public DbSet<Person> Persons { get; set; }

    public PersonContext()
    {
        Database.EnsureCreated();
    }

    public PersonContext(DbContextOptions<PersonContext> options) 
        : base(options) 
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config  = new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .Build();

        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
