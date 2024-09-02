using CrudCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class Login : IdentityDbContext<IdentityUser>
{
    public Login(DbContextOptions<Login> options) : base(options)
    {
    }

    public DbSet<Detail1> Details { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}