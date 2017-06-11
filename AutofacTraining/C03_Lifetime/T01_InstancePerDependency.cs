using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C03_Lifetime
{
	class T01_InstancePerDependency : ContainerTest
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
			builder.RegisterType<ProductService>().InstancePerDependency();
			builder.RegisterType<ProductDao>().InstancePerDependency();
		}

		[Test]
		public void CreateProductService()
		{
			Resolve<ProductService>();
			Resolve<ProductService>();
		}
	}
}