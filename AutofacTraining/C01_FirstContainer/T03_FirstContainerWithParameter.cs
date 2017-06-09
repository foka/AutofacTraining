using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C01_FirstContainer
{
	class T03_WithParameter
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

		[Test]
		public void CreateProductService()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<ProductService>();
			builder.RegisterType<ProductDao>()
				.WithParameter("timeout", 3000);
//				.WithParameter(new NamedParameter("timeout", 3000));
//				.WithParameter(new TypedParameter(typeof(int), 3000));
//				.WithParameter(new PositionalParameter(0, 3000));
//				.WithParameter((info, context) => info.Name == "timeout", (info, context) => 3000);
			var container = builder.Build();

			var productService = container.Resolve<ProductService>();
		}
	}
}