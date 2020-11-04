using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Application.Write.Models
{
    public class BookForCreation
    {
        public string Title { get; set; }
        public IEnumerable<string> Authors { get; set; }
        public string Thumbnail { get; set; }
        public string PublishedYear { get; set; }
        public string ExternalId { get; set; }
    }
}
