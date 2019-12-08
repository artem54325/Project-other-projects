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

        protected virtual DbSet<Post> Posts { get; set; }
        protected virtual DbSet<Project> Projects { get; set; }

    }
}
