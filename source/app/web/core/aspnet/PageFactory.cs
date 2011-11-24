using System.Web;

namespace app.web.core.aspnet
{
  public class PageFactory : ICreateAResponse
  {
  	private IFindPathsToViews page_path_registry;

		public PageFactory(IFindPathsToViews page_path_registry)
  	{
			this.page_path_registry = page_path_registry;
  	}

  	public IHttpHandler create_using<ReportModel>(ReportModel model)
  	{
  		this.page_path_registry.find_path_for<ReportModel>();
  		return null;
  	}
  }
}