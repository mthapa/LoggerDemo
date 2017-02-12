using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using CommonServiceLocator.WindsorAdapter.Unofficial;
using LoggerLibrary;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			var container = new WindsorContainer();

			container.Register(Component.For<IWindsorContainer>().Instance(container).LifeStyle.Singleton);
			container.Register(Component.For<IServiceLocator> ().ImplementedBy<WindsorServiceLocator>().LifeStyle.Singleton);

			container.Install(FromAssembly.This(),
				 FromAssembly.InDirectory(new AssemblyFilter(".", "*Logger*"))
				);

			
			/*
			foreach ( var handler in container.Kernel.GetAssignableHandlers(typeof(object)))
			{
				Console.WriteLine("Registered: {0} for {1} (lifestyle: {2})",
					handler.ComponentModel.Implementation.FullName,
					String.Join(", ", handler.ComponentModel.Services.Select(t => t.FullName)),
					handler.ComponentModel.LifestyleType);
			}
			*/

			ServiceLocator.SetLocatorProvider(() => container.Resolve<IServiceLocator>());


			var logger = ServiceLocator.Current.GetInstance<ILogger>();
			logger.Log("Helo World");
			Console.ReadKey();

		}
	}
}
