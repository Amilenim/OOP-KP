using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Test_Site.Models;

public class TutorsContext : IdentityDbContext
{
    public DbSet<TutorsModel> TutorsModels { get; set; }

    public TutorsContext(DbContextOptions<TutorsContext> options) : base(options)
    {

    }
}