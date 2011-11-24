using System.Web;

namespace app.web.core.aspnet
{
  public interface ICreateAResponse
  {
    IHttpHandler create_using<ReportModel>(ReportModel model);
  }
}