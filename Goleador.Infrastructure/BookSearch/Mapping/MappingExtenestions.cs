using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Goleador.Application.Read.Models;
using Google.Apis.Books.v1.Data;

namespace Goleador.Infrastructure.BookSearch.Mapping
{
    public static class MappingExtensions
    {
        public static SearchedBookCollection MapToSearchedBookCollection(this Volumes volumes) 
        {
            return new SearchedBookCollection()
            {
                TotalItems = volumes.TotalItems ?? 0,
                Items = volumes.Items.Select(x => new SearchedBookItem()
                {
                    Title = x.VolumeInfo.Title,
                    Thumbnail = x.VolumeInfo.ImageLinks == null ? string.Empty : x.VolumeInfo.ImageLinks.Thumbnail,
                    Authors = x.VolumeInfo.Authors,
                    PublishedDate = x.VolumeInfo.PublishedDate,
                    Id = x.Id
                })
            };
        }
    }
}
