using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Read.Models
{
    public class SearchedBookCollection
    {
        public int TotalItems { get; set; }
        public IEnumerable<SearchedBookItem> Items { get; set; }
    }
}
