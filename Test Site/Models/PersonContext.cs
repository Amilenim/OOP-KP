using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Test_Site.Models;

public class PersonContext : IdentityDbContext
{
    public DbSet<Person> Persons { get; set; }

    public PersonContext(DbContextOptions<PersonContext> options) : base(options)
    {
        
    }
}