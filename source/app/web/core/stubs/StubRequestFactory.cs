using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IContainRequestInformation create_from(HttpContext the_context)
    {
      return new StubRequest();
    }

    class StubRequest : IContainRequestInformation
    {
    }
  }
}