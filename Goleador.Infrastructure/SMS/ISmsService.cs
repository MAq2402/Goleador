using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Goleador.Infrastructure.SMS
{
    public interface ISmsService
    {
        Task SendMessageAboutBooksInReadAsync(string from, string to, string text);
    }
}
