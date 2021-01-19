using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Linq;

namespace Goleador.Web.Filters
{
    public class CacheFilter : ActionFilterAttribute, IActionFilter
    {
        private readonly IDistributedCache _cache;

        public CacheFilter(IDistributedCache cache)
        {
            _cache = cache;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result as OkObjectResult;
            _cache.SetString(CreateKey(context), JsonConvert.SerializeObject(result.Value));
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var result = _cache.GetString(CreateKey(context));

            if (result != null)
            {
                context.Result = new OkObjectResult(JsonConvert.DeserializeObject(result));
            }
        }

        private string CreateKey(FilterContext context)
        {
            var actionName = context.ActionDescriptor.DisplayName;
            var args = context.ActionDescriptor.Parameters.Select(p => p.Name);
            return $"{actionName}_{string.Join(',', args)}";
        }
    }
}
