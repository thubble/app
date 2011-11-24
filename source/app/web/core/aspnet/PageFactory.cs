using System.Web;
using System.Web.UI;

namespace app.web.core.aspnet
{
  public class PageFactory : ICreateAResponse
  {
  	private IFindPathsToViews page_path_registry;
  	private TemplateFactory template_factory;

		public PageFactory(IFindPathsToViews page_path_registry, TemplateFactory template_factory)
		{
			this.page_path_registry = page_path_registry;
			this.template_factory = template_factory;
		}

  	public IHttpHandler create_using<ReportModel>(ReportModel model)
  	{
  		string path = this.page_path_registry.find_path_for<ReportModel>();
  		return template_factory(path, typeof(Page)) as IHttpHandler;
  	}
  }
}