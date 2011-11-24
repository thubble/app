namespace app.web.core
{
	public interface IMapRequestsToPaths
	{
		IContainRequestInformation get_request_that_can_handle_path(string path);
	}
}
