using System.Web;

namespace app.web.core.aspnet
{
  public class WebResponseEngine : IDisplayReportModels
  {
    ICreateAResponse response_factory;
    CurrentContextResolver current_context;

    public WebResponseEngine(ICreateAResponse response_factory, CurrentContextResolver current_context)
    {
      this.response_factory = response_factory;
      this.current_context = current_context;
    }

    public WebResponseEngine(ICreateAResponse response_factory):this(response_factory,() => HttpContext.Current)
    {
    }

    public void display<ReportModel>(ReportModel model)
    {
      response_factory.create_using(model).ProcessRequest(current_context());
    }
  }
}