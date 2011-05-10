using System.Web.Mvc;
using Munq.MVC3;
using RestfulMvcExample.Models;

[assembly: WebActivator.PreApplicationStartMethod(
	typeof(RestfulMvcExample.App_Start.MunqMvc3Startup), "PreStart")]

namespace RestfulMvcExample.App_Start {
	public static class MunqMvc3Startup {
		public static void PreStart() {
			DependencyResolver.SetResolver(new MunqDependencyResolver());
			var ioc = MunqDependencyResolver.Container;

            ioc.Register<IContactRepository, ContactRepository>();
		}
	}
}
