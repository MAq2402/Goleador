using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Read.Models
{
    public class SearchedBookItem
    {
        public string Title { get; set; }
        public string Thumbnail { get; set; }
        public IEnumerable<string> Authors { get; set; } = new List<string>();
        public string PublishedDate { get; set; }
        public string Id { get; set; }
    }
}
