using System;
using System.Collections.Generic;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C01_FirstContainer
{
	class T05_IEnumerable
	{
		class ProductService
		{
			public ProductService(IEnumerable<IProductDao> productDaos)
			{
				this.productDaos = productDaos;
			}

			public void Save()
			{
				foreach (var dao in productDaos)
					dao.Save();
			}

			private readonly IEnumerable<IProductDao> productDaos;
		}

		interface IProductDao { void Save(); }

		class InternalProductDao : IProductDao
		{
			public void Save() { Console.WriteLine("Internal Save "); }
		}

		class ExternalProductDao : IProductDao
		{
			public void Save() { Console.WriteLine("External Save "); }
		}

		[Test]
		public void Save()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<ProductService>();
			builder.RegisterType<InternalProductDao>().As<IProductDao>();
			builder.RegisterType<ExternalProductDao>().As<IProductDao>();

			var container = builder.Build();

			var productService = container.Resolve<ProductService>();
			productService.Save();
		}
	}
}