using System;
using Autofac;
using NUnit.Framework;

namespace AutofacTraining.C05_Extras
{
	// Kolega na szkoleniu spytał czy Autofac obsługuje serwis Lazy<T>
	// tak jak Func<T>. Poniższy test pokazuje, że Lazy<T> działa!
	// Oczywiście, jak to przy Lazy, komponent tworzony jest tylko raz.
	class T01_LazyDependency
	{
		class ProductService
		{
			public ProductService(Lazy<ProductDao> lazyProductDao)
			{
				this.lazyProductDao = lazyProductDao;
				Console.WriteLine("ProductService ctor");
			}

			public void Save()
			{
				lazyProductDao.Value.Save();
			}

			private readonly Lazy<ProductDao> lazyProductDao;
		}

		class ProductDao
		{
			public ProductDao()
			{
				Console.WriteLine("ProductDao ctor");
			}

			public void Save()
			{
				Console.WriteLine("ProductDao Save");
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
			productService.Save();
			productService.Save();

//			Output:
//			ProductService ctor
//			ProductDao ctor
//			ProductDao Save
//			ProductDao Save
		}
	}
}