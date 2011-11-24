using System.Web.UI;

namespace app.web.core.aspnet
{
  public class View<ViewModel>: Page,IDisplayA<ViewModel>
  {
    public ViewModel model { get; set; }
  }
}