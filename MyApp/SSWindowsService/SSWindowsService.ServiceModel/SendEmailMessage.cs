using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace SSWindowsService.ServiceModel
{
    public class SendEmailMessage : IReturn<SendEmailResponse>
    {
        public string Name { get; set; }
    }

    public class SendEmailResponse
    {
        public string Result { get; set; }
    }
}