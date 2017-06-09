using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C01_FirstContainer
{
	public class T06_Func
	{
		class ProductService
		{
			public ProductService(Func<ProductDao> getProductDao)
			{
				this.getProductDao = getProductDao;
				Console.Out.WriteLine("ProductService ctor");
			}

			public void Save()
			{
				var dao = getProductDao();
				dao.Save();
			}

			private readonly Func<ProductDao> getProductDao;
		}

		class ProductDao
		{
			public ProductDao() { Console.WriteLine("ProductDao ctor"); }

			public void Save() { Console.WriteLine("ProductDao Save"); }
		}

		[Test]
		public void Save()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<ProductService>();
			builder.RegisterType<ProductDao>();

			var container = builder.Build();

			var productService = container.Resolve<ProductService>();
			productService.Save();
		}
	}
}