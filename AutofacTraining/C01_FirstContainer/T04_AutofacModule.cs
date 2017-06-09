using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C01_FirstContainer
{
	class T04_AutofacModule
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
			public ProductDao(int timeout)
			{
				Console.WriteLine("ProductDao ctor: " + timeout);
			}
		}

		class ProductModule : Module
		{
			protected override void Load(ContainerBuilder builder)
			{
				builder.RegisterType<ProductService>();
				builder.RegisterType<ProductDao>()
					.WithParameter("timeout", 3000);
			}
		}

		[Test]
		public void CreateProductService()
		{
			var builder = new ContainerBuilder();

			builder.RegisterModule<ProductModule>();

			var container = builder.Build();

			var productService = container.Resolve<ProductService>();
		}
	}
}