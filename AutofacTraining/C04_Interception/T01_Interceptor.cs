using System;
using System.Diagnostics;
using System.Threading;
using Autofac;
using Autofac.Extras.DynamicProxy2;
using Castle.DynamicProxy;
using NUnit.Framework;

namespace AutofacTraining.C04_Interception
{
	class T01_Interceptor : ContainerTest
	{
		public class ProductService
		{
			public ProductService()
			{
				Console.WriteLine("ProductService ctor");
			}

			public virtual void Save()
			{
				Console.WriteLine("ProductService Save");
				Thread.Sleep(500);
			}
		}

		public class InvocationTimeLogger : IInterceptor
		{
			public void Intercept(IInvocation invocation)
			{
				var stopwatch = new Stopwatch();
				stopwatch.Start();
				
				invocation.Proceed();

				stopwatch.Stop();
				Console.WriteLine("{0}.{1} took {2}",
					invocation.TargetType.Name, invocation.Method.Name, stopwatch.Elapsed);
			}
		}

		protected override void RegisterComponents(ContainerBuilder builder)
		{
			builder.RegisterType<ProductService>()
				.EnableClassInterceptors()
				.InterceptedBy(typeof(InvocationTimeLogger));

			builder.RegisterType<InvocationTimeLogger>();
		}

		[Test]
		public void SaveWithInterception()
		{
			var productService = Resolve<ProductService>();
			productService.Save();
		}
	}
}