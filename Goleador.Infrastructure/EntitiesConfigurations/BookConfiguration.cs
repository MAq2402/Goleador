using System;
using System.Collections.Generic;
using System.Text;
using Goleador.Domain.Book;
using Goleador.Domain.Pomodoro;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Goleador.Infrastructure.EntitiesConfigurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);

            builder.OwnsMany(b => b.Pomodoros, p =>
            {
                p.WithOwner().HasForeignKey("BookId");
                p.Property<Guid>("Id");
                p.HasKey("Id");
            });

            builder.Metadata.FindNavigation(nameof(Book.Pomodoros))
                .SetPropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
