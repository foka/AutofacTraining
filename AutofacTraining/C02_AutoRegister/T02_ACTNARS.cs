using System;
using Autofac;
using Autofac.Features.ResolveAnything;
using NUnit.Framework;

namespace AutofacTraining.C02_AutoRegister
{
	class T02_ACTNARS
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
			public ProductDao(Database database)
			{
				Console.WriteLine("ProductDao ctor");
			}
		}

		class Database
		{
			public Database()
			{
				Console.WriteLine("Database ctor");
			}
		}

		[Test]
		public void CreateProductService()
		{
			var builder = new ContainerBuilder();
			
			builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
			
			var container = builder.Build();

			var productService = container.Resolve<ProductService>();
		}
	}
}