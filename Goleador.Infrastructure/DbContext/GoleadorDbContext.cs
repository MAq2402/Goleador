using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Domain.Book;
using Goleador.Domain.Pomodoro;
using Microsoft.EntityFrameworkCore;

namespace Goleador.Infrastructure.DbContext
{
    public class GoleadorDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public GoleadorDbContext(DbContextOptions<GoleadorDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Pomodoro> Pomodoros { get; set; }
    }
}
