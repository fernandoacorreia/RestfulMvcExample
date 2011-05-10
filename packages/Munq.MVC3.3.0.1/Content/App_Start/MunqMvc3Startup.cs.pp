using System.Web.Mvc;
using Munq.MVC3;

[assembly: WebActivator.PreApplicationStartMethod(
	typeof($rootnamespace$.App_Start.MunqMvc3Startup), "PreStart")]

namespace $rootnamespace$.App_Start {
	public static class MunqMvc3Startup {
		public static void PreStart() {
			DependencyResolver.SetResolver(new MunqDependencyResolver());
			var ioc = MunqDependencyResolver.Container;

			// TODO: Register Dependencies
			// ioc.Register<IMyRepository, MyRepository>();
		}
	}
}
 

