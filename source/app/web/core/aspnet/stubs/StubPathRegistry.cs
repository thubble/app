namespace app.web.core.aspnet.stubs
{
  public class StubPathRegistry : IFindPathsToViews
  {
    public string find_path_for<ViewModel>()
    {
      return path_to("departmentbrowser");
    }

    string path_to(string page)
    {
      return string.Format("~/views/{0}.aspx", page);
    }
  }
}