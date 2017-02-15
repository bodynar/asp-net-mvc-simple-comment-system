namespace AspNetMvc.SimpleCommentSystem
{
    #region References
    using System.Data.Entity;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AspNetMvc.SimpleCommentSystem.EF;
    using AspNetMvc.SimpleCommentSystem.Mappers;
    #endregion

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Database.SetInitializer(new AppDbInitializer());

            AutoMapperConfig.ConfigureMapper();
        }
    }
}
