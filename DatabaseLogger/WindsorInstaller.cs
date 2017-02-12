using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace LoggerDemo
{
	public class WindsorInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Classes.FromThisAssembly().
					Where(t => t.Name.EndsWith("Logger")).
					WithServiceAllInterfaces().
					WithServiceSelf().
					LifestyleSingleton()
			);
		}
	}
}
