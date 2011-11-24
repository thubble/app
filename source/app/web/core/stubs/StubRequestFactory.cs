using System;
using System.Web;

namespace app.web.core.stubs
{
  public class StubRequestFactory : ICreateRequests
  {
    public IContainRequestInformation create_from(HttpContext the_context)
    {
      return Stub.with<StubRequest>();
    }

    class StubRequest : IContainRequestInformation
    {
      public ViewModel map<ViewModel>()
      {
        object val = Activator.CreateInstance<ViewModel>();
        return (ViewModel) val;
      }
    }
  }
}