using System;
using System.Linq;
using System.Reflection;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C02_AutoRegister
{
	class T01_AssemblyScanning : ContainerTest
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

		protected override void RegisterComponents(ContainerBuilder builder)
		{
			var thisAssembly = Assembly.GetExecutingAssembly();

			builder.RegisterAssemblyTypes(thisAssembly)
//				.Where(t => t.Name.EndsWith("Dao"))
//				.Where(t => t.GetInterfaces().Contains(typeof(IDatabaseService)))
				.AsImplementedInterfaces();

//			builder.RegisterAssemblyModules(thisAssembly);
		}

		[Test]
		public void CreateProductService()
		{
			var productService = Resolve<IProductService>();
		}
	}
}