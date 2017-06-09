using System;
using System.Reflection;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C02_AutoRegister
{
	class T01_AssemblyScanning
	{
		interface IProductService
		{
		}

		class ProductService : IProductService
		{
			public ProductService(IProductDao productDao)
			{
				Console.WriteLine("ProductService ctor");
			}
		}

		interface IProductDao
		{
		}

		class ProductDao : IProductDao
		{
			public ProductDao()
			{
				Console.WriteLine("ProductDao ctor");
			}
		}

		[Test]
		public void CreateProductService()
		{
			var builder = new ContainerBuilder();

			var thisAssembly = Assembly.GetExecutingAssembly();
			builder.RegisterAssemblyTypes(thisAssembly)
//				.Where(t => t.Name.EndsWith("Dao"))
				.AsImplementedInterfaces();

//			builder.RegisterAssemblyModules(thisAssembly);

			var container = builder.Build();

			var productService = container.Resolve<IProductService>();
		}
	}
}