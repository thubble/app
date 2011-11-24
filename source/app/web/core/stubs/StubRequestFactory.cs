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

			public MappableType map<MappableType>()
      {
        object department = new Department();
				return (MappableType)department;
      }


			public MappableType map<MappableType, MappableParentType>(MappableParentType parent)
			{
				throw new System.NotImplementedException();
			}
		}
  }
}