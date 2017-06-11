using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C03_Lifetime
{
	class T03_LifetimeScope : ContainerTest
	{
		class ProductService
		{
			public ProductService(ProductDao productDao)
			{
				Console.WriteLine("ProductService ctor");
			}
		}

		class ProductDao
		{
			public ProductDao()
			{
				Console.WriteLine("ProductDao ctor");
			}
		}

		protected override void RegisterComponents(ContainerBuilder builder)
		{
			builder.RegisterType<ProductService>().InstancePerLifetimeScope();
			builder.RegisterType<ProductDao>();
		}

		[Test]
		public void CreateInScopes()
		{
			using (var scope1 = container.BeginLifetimeScope())
			{
				Console.WriteLine("Begin Scope 1");
				scope1.Resolve<ProductService>();
				scope1.Resolve<ProductService>();
				Console.WriteLine("End Scope 1");
			}

			using (var scope2 = container.BeginLifetimeScope())
			{
				Console.WriteLine("Begin Scope 2");
				scope2.Resolve<ProductService>();
				scope2.Resolve<ProductService>();
				Console.WriteLine("End Scope 2");
			}
		}
	}
}