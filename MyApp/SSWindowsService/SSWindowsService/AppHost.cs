using Funq;
using ServiceStack;
using ServiceStack.Azure.Messaging;
using SSWindowsService.ServiceInterface;
using SSWindowsService.ServiceModel;

namespace SSWindowsService
{
    //VS.NET Template Info: https://servicestack.net/vs-templates/EmptyWindowService
    public class AppHost : AppSelfHostBase
    {
        /// <summary>
        /// Base constructor requires a Name and Assembly where web service implementation is located
        /// </summary>
        public AppHost()
            : base("SSWindowsService", typeof(MyServices).Assembly) { }

        /// <summary>
        /// Application specific configuration
        /// This method should initialize any IoC resources utilized by your web service classes.
        /// </summary>
        public override void Configure(Container container)
        {
            //Config examples
            //this.Plugins.Add(new PostmanFeature());
            //this.Plugins.Add(new CorsFeature());

            var mqServer = new ServiceBusMqServer("sb-connection");
            mqServer.RegisterHandler<SendEmailMessage>(ExecuteMessage);
            mqServer.Start();

            //works here but not in MyApp
            using (var mqClient = mqServer.CreateMessageQueueClient())
            {
                mqClient.Publish(new SendEmailMessage());
            }



        }
    }
}
