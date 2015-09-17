using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using System.Threading.Tasks;

[assembly: OwinStartup(typeof(Server.Startup))]

namespace Server
{
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();

            RandomGenerator randomGenerator = new RandomGenerator(Globals.Delay);
            Task.Factory.StartNew(async () => await randomGenerator.OnRandomMonitor());
        }
    }
}
