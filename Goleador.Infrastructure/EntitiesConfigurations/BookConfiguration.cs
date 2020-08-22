using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Domain.Book;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goleador.Infrastructure.EntitiesConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.HasMany(b => b.Pomodoros)
                .WithOne(p => p.Book);

            builder.Metadata.FindNavigation(nameof(Book.Pomodoros))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
