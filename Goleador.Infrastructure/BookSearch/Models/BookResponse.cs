using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Infrastructure.BookSearch.Models
{
    public class BookResponse
    {
        public int TotalItems { get; set; }
        public IEnumerable<Item> Items { get; set; }
    }
}
