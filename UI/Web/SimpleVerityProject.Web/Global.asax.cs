using ProjectVerity.Services;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleVerityProject.Services.Interfaces;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SimpleVerityProject.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var container = new Container();

            container.Register<IProdutoService, ProdutoService>(Lifestyle.Singleton);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration); //web api          
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container); //web api
        }
    }
}
