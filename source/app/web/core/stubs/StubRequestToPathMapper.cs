using System;

namespace app.web.core.stubs
{
	class StubRequestToPathMapper : IMapRequestsToPaths
	{
		public IContainRequestInformation get_request_that_can_handle_path(string path)
		{
			throw new NotImplementedException();
		}
	}
}
