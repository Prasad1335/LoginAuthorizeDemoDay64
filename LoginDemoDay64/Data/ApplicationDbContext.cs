using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LoginDemoDay64.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LoginDemoDay64.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser, IdentityRole, string>
    {
        public DbSet<Movie> movies { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Nationality> Nationalities { get; set; }
      
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    //    public partial class ApplicationDbContext : DbContext
    //{
      
      
    //    public virtual DbSet<Department> Departments { get; set; }
    //    public virtual DbSet<Employee> Employees { get; set; }
    //    public virtual DbSet<Nationality> Nationalities { get; set; }
    //    public virtual DbSet<Movie> movies { get; set; }

    //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    //    {
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        if (!optionsBuilder.IsConfigured)
    //        {
    //            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-IU72N5R;Initial Catalog=MovieTheaterManagment;Integrated Security=True");
    //        }
    //    }

    
    }
}
