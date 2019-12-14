using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjectAboutProjects.Models;

namespace ProjectAboutProjects.DAL
{
    public class MySqlContext : IdentityDbContext<ApplicationUser>
    {
        //public MySqlContext(DbContextOptions<MySqlContext> options):base(options)
        //{
        //}

        public MySqlContext(DbContextOptions options) : base(options)
        {
            //this.Database.EnsureCreated();
        }

        protected MySqlContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
