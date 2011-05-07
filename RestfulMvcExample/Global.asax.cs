using System.Web.Mvc;
using System.Web.Routing;

namespace RestfulMvcExample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Generic CRUD routes
            routes.MapRoute(
                "get-index",
                "{controller}",
                new { controller = "Home", action = "Index" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );
            routes.MapRoute(
                "get-object",
                "{controller}/{id}",
                new { action = "Get" },
                new { httpMethod = new HttpMethodConstraint("GET") }
            );
            routes.MapRoute(
                "post-object",
                "{controller}",
                new { action = "Post" },
                new { httpMethod = new HttpMethodConstraint("POST") }
            );
            routes.MapRoute(
                "put-object",
                "{controller}/{id}",
                new { action = "Put" },
                new { httpMethod = new HttpMethodConstraint("PUT") }
            );
            routes.MapRoute(
                "delete-object",
                "{controller}/{id}",
                new { action = "Delete" },
                new { httpMethod = new HttpMethodConstraint("DELETE") }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}