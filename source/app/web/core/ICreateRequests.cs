using System.Web;

namespace app.web.core
{
  public interface ICreateRequests
  {
    IContainRequestInformation create_from(HttpContext the_context);
  }
}