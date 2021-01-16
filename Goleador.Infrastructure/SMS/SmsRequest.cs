using System;
using System.Collections.Generic;
using System.Text;

namespace Goleador.Infrastructure.SMS
{
    public class SMSRequest : Nexmo.Api.SMS.SMSRequest
    {
        // Names of properties have to start with lowercase character
        public string from { get; set; }
        public string to { get; set; }
        public string text { get; set; }
    }
}
