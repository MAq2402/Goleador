
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Goleador.Application.Read.Models;
using Goleador.Application.Read.Services;
using Goleador.Infrastructure.BookSearch.Mapping;
using Goleador.Infrastructure.Types;
using Google.Apis.Books.v1;
using Google.Apis.Services; 

namespace Goleador.Infrastructure.BookSearch.Services
{
    public class BookSearchService : IBookSearchService
    {
        private readonly GoogleBooksApiSettings _googleBooksApiSettings;

        public BookSearchService(Settings settings)
        {
            _googleBooksApiSettings = settings.GoogleBooksApiSettings;
        }

        public async Task<SearchedBookCollection> SearchAsync(string query)
        {
            var service = new BooksService(new BaseClientService.Initializer
                {
                    ApplicationName = "Goleador",
                    ApiKey = _googleBooksApiSettings.Key
                });
            

            var listRequest = service.Volumes.List();
            listRequest.Q = query;

            return (await listRequest.ExecuteAsync()).MapToSearchedBookCollection();
        }
    }
}