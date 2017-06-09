using System;
using Autofac;
using Autofac.Features.ResolveAnything;
using NUnit.Framework;

namespace AutofacTraining.C02_AutoRegister
{
	class T02_ACTNARS : ContainerTest
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


		protected override void RegisterComponents(ContainerBuilder builder)
		{
			builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());
		}

		[Test]
		public void CreateProductService()
		{
			var productService = Resolve<ProductService>();
		}
	}
}