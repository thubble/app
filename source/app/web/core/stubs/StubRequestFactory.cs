using System.Web;
using app.web.application;

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
        public Department Department
        {
            get { return new Department() {name = "Department 0"}; }
            set { throw new System.NotImplementedException(); }
        }
    }
  }
}