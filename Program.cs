using DesignPatterns.App;
using DesignPatterns.SOLID;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using IHost host = Host.CreateDefaultBuilder(args)
.ConfigureServices((hbc, services) =>
{
    //Services go here
})
.Build();
var svc = ActivatorUtilities.CreateInstance<App>(host.Services);
//svc.Entry();
svc.BuilderRoutine();
svc.FactoryRoutine();