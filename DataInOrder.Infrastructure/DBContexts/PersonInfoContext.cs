using Microsoft.EntityFrameworkCore;
using DataInOrder.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace DataInOrder.Infrastructure.DBContexts;

public class PersonInfoContext: DbContext
{
    DbSet<PersonInfo> PersonsInfo { get; set; }

    public PersonInfoContext()
    {
        Database.EnsureCreated();
    }

    public PersonInfoContext(DbContextOptions<PersonInfoContext> options) 
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
