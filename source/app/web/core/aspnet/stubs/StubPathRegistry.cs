using System.Collections.Generic;
using app.web.application;

namespace app.web.core.aspnet.stubs
{
  public class StubPathRegistry:IFindPathsToViews
  {
    public string find_path_for<ViewModel>()
    {
      if (typeof(ViewModel) == typeof(IEnumerable<Department>)) return path_to("departmentbrowser");
      return path_to("productbrowser");
    }

    string path_to(string page)
    {
      return string.Format("~/views/{0}.aspx", page);
    }
  }
}