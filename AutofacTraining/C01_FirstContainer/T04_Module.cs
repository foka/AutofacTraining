using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C01_FirstContainer
{
	public class T04_FirstContainerModule
	{
		class ProductService
		{
			public ProductService(ProductDao productDao)
			{
				Console.Out.WriteLine("ProductService ctor");
			}
		}

		class ProductDao
		{
			public ProductDao(int timeout)
			{
				Console.Out.WriteLine("ProductDao ctor: " + timeout);
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