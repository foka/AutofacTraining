using Autofac;
using NUnit.Framework;

namespace AutofacTraining
{
	abstract class ContainerTest
	{
		protected abstract void RegisterComponents(ContainerBuilder builder);

		protected T Resolve<T>()
		{
			return container.Resolve<T>();
		}

		[SetUp]
		public void CreateContainer()
		{
			var builder = new ContainerBuilder();
			RegisterComponents(builder);
			container = builder.Build();
		}

		private IContainer container;
	}
}