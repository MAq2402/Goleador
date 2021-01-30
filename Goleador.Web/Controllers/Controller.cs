using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Goleador.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Controller : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly IDistributedCache _cache;

        protected string UserId
        {
            get
            {
                return User.Claims.FirstOrDefault(c => c.Type == "userId")?.Value;
            }
        }

        public Controller(IMediator mediator, IDistributedCache cache)
        {
            _mediator = mediator;
            _cache = cache;
        }

        protected async Task<T> GetCacheAsync<T>(string key)
        {
            var value = await _cache.GetStringAsync(key);
            return string.IsNullOrEmpty(value) ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }

        protected async Task SetCacheAsync<T>(string key, T books)
        {
            await _cache.SetStringAsync(key, JsonConvert.SerializeObject(books));
        }
    }
}
