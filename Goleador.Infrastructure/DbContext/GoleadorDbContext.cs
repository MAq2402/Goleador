using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Goleador.Domain.Book;
using Goleador.Domain.Pomodoro;
using Goleador.Infrastructure.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Goleador.Infrastructure.DbContext
{
    public class GoleadorDbContext : IdentityDbContext<User>
    {
        public GoleadorDbContext(DbContextOptions<GoleadorDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(GoleadorDbContext)));

            base.OnModelCreating(modelBuilder);
        }
    }
}
