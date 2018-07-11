using ServiceStack;
using SSWindowsService.ServiceModel;

namespace SSWindowsService.ServiceInterface
{
    public class MyServices : Service
    {
        public object Any(SendEmailMessage request)
        {
            return new SendEmailResponse { Result = $"Hello, {request.Name}!" };
        }
    }
}