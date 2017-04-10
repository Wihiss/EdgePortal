using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using EdgePortal.Storage.Interfaces;
using EdgePortal.Infrastructure.DI;
using FamilyPortal.Storage.Impl.Mongo;
using System.Configuration;

namespace EdgePortal
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            /*NinjectResolver.Instance.BindAsSingletone<IStorage, MongoStorage>().WithConstructorArgument("dbConnection",
                ConfigurationManager.ConnectionStrings["EdgePortal"].ConnectionString);*/
           }
    }
}
