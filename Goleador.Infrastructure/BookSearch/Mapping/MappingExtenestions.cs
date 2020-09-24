using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goleador.Infrastructure.BookSearch.Models;
using Google.Apis.Books.v1.Data;

namespace Goleador.Infrastructure.BookSearch.Mapping
{
    public static class MappingExtensions
    {
        public static BookResponse MapToBookResponse(this Volumes volumes) 
        {
            return new BookResponse()
            {
                TotalItems = volumes.TotalItems ?? 0,
                Items = volumes.Items.Select(x => new Item()
                {
                    Title = x.VolumeInfo.Title,
                    Thumbnail = x.VolumeInfo.ImageLinks.SmallThumbnail,
                    Authors = x.VolumeInfo.Authors,
                    PublishedDate = x.VolumeInfo.PublishedDate,
                    Id = x.Id
                })
            };
        }
    }
}
