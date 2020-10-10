using System;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Reflection;
using Application.Contract;
using MartianRobots.Contracts;

namespace MartianRobots.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var modulesPath = Path.Combine(assemblyLocation!, "..\\Modules\\netstandard2.0");

            //Setup the container
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new AssemblyCatalog(typeof(Program).Assembly));
            catalog.Catalogs.Add(new DirectoryCatalog(modulesPath));

            var container = new CompositionContainer(catalog);

            container.Compose(new CompositionBatch());
            var application = container.GetExportedValue<IApplication>();

            application.Run();
        }
    }
}
