using System.Web;

namespace app.web.core.aspnet
{
  public interface IDisplayA<ViewModel>:IHttpHandler
  {
    ViewModel model { get; set; }
  }
}