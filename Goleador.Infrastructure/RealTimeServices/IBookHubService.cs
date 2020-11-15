using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.RealTimeServices
{
    public interface IBookHubService
    {
        Task SendAsync(object data, string userId);
    }
}
