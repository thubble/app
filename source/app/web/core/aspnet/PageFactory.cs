using System.Web;

namespace app.web.core.aspnet
{
  public class PageFactory : ICreateAResponse
  {
    public IHttpHandler create_using<ReportModel>(ReportModel model)
    {
      throw new System.NotImplementedException();
    }
  }
}