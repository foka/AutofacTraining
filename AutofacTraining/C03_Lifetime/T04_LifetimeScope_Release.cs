using System;
using Autofac;
using Autofac.Features.OwnedInstances;
using NUnit.Framework;

namespace AutofacTraining.C03_Lifetime
{
	class T04_LifetimeScope_Release : ContainerTest
	{
		interface IProductService { }

		class ProductService : IProductService, IDisposable
		{
			public ProductService()
			{
				Console.WriteLine("ProductService ctor");
			}

			public void Dispose()
			{
				Console.WriteLine("ProductService Dispose");
			}

			~ProductService()
			{
				Dispose();
			}
		}

		protected override void RegisterComponents(ContainerBuilder builder)
		{
			builder.RegisterType<ProductService>()
				.As<IProductService>();
		}

		[Test]
		public void CreateFromScope_Releases()
		{
			using (var scope = container.BeginLifetimeScope())
			{
				Console.WriteLine("Begin Scope");
				scope.Resolve<IProductService>();
				scope.Resolve<IProductService>();
				Console.WriteLine("End Scope");
			}

			Console.WriteLine("After Scope");
		}

		[Test]
		public void CreateFromRootContainer_DoesntRelease()
		{
			{
				container.Resolve<IProductService>();
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		[Test]
		public void CreateOwnedFromRootContainer_Releases()
		{
			{
				container.Resolve<Owned<IProductService>>();
			}

			GC.Collect();
			GC.WaitForPendingFinalizers();
		}
	}
}