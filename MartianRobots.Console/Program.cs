﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Numerics;
using System.Reflection;
using MartianRobots.Contracts;

namespace MartianRobots.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var assemblyLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (assemblyLocation == null)
            {
                throw new InvalidOperationException("Failed to get assembly location.");
            }

            var modulesPath = Path.Combine(assemblyLocation, "Modules");

            var marsSurfaceFactory = new MarsSurfaceFactory();
            var moveCoordinator = new MoveCoordinator();
            var martianRobotFactory = new MartianRobotFactory( moveCoordinator );

            //using (var dc = new DirectoryCatalog(modulesPath))
            //{
            //    using (var container = new CompositionContainer(dc))
            //    {
            //        marsSurfaceFactory = container.GetExportedValue<IMarsSurfaceFactory>();
            //        martianRobotFactory = container.GetExportedValue<IMartianRobotFactory>();
            //    }
            //}

            
        }
    }
}
