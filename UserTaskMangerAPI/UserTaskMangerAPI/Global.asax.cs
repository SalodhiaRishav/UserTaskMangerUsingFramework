namespace UserTaskMangerAPI
{
    using System;
    using ServiceStack.Logging;
    using ServiceStack.Logging.Log4Net;

    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            LogManager.LogFactory = new Log4NetFactory(configureLog4Net: true);
            new AppHost().Init();
        }
    }
}