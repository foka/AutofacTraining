using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C01_FirstContainer
{
	class T02_AsInterface
	{
		interface IProductService { }

		interface IProductDao { }

		class ProductService : IProductService
		{
			public ProductService(IProductDao productDao)
			{
				Console.Out.WriteLine("ProductService ctor");
			}
		}

		class ProductDao : IProductDao
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

			builder.RegisterType<ProductService>().As<IProductService>();
			builder.RegisterType<ProductDao>().As<IProductDao>();

			var container = builder.Build();

			var productService = container.Resolve<IProductService>();
		}
	}
}
