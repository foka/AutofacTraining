using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C03_Lifetime
{
	class T02_SingleInstance : ContainerTest
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
			public ProductDao()
			{
				Console.WriteLine("ProductDao ctor");
			}
		}


		protected override void RegisterComponents(ContainerBuilder builder)
		{
			builder.RegisterType<ProductService>();
			builder.RegisterType<ProductDao>().SingleInstance();
		}

		[Test]
		public void CreateProductService()
		{
			Resolve<ProductService>();
			Resolve<ProductService>();
		}
	}
}