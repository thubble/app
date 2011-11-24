using System;
using System.Web;
using app.web.core.stubs;

namespace app.web.core
{
	public class BasicRequestFactory : ICreateRequests
	{
		private IMapRequestsToPaths request_path_mapper;

		public BasicRequestFactory() : this(Stub.with<StubRequestToPathMapper>())
		{
			
		}

		public BasicRequestFactory(IMapRequestsToPaths requestPathMapper)
		{
			request_path_mapper = requestPathMapper;
		}

		public IContainRequestInformation create_from(HttpContext the_context)
		{
			return request_path_mapper.get_request_that_can_handle_path(the_context.Request.Path);
		}
	}
}
