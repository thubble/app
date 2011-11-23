using System.Web;
using app.web.application;

namespace app.web.core.stubs
{
  public class StubResponseEngine:IDisplayReportModels
  {
    public void display<ReportModel>(ReportModel model)
    {
      HttpContext.Current.Items.Add("blah",model);
      HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
    }
  }
}