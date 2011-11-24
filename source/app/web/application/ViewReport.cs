using app.web.core;
using app.web.core.aspnet;
using app.web.core.stubs;

namespace app.web.application
{
  public class ViewReport<TResponse> : IImplementAUseCase
  {
    IRunQuery<TResponse> query;
    IDisplayReportModels response_gateway;

    public ViewReport(IRunQuery<TResponse> query, IDisplayReportModels response_gateway)
    {
      this.query = query;
      this.response_gateway = response_gateway;
    }

	public ViewReport(IRunQuery<TResponse> query)
		: this(query, new WebResponseEngine())
    {
    }

    public void process(IContainRequestInformation request)
    {
      response_gateway.display(query.run_using(request));
    }
  }
}