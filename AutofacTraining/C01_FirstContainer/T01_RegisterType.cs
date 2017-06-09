using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C01_FirstContainer
{
	class T01_RegisterType
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
			public ProductDao()
			{
				Console.Out.WriteLine("ProductDao ctor");
			}
		}

		[Test]
		public void CreateProductService()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<ProductService>();
			builder.RegisterType<ProductDao>();

			var container = builder.Build();

			var productService = container.Resolve<ProductService>();
		}
	}
}
