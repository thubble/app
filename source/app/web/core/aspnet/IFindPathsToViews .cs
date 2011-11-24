namespace app.web.core.aspnet
{
  public interface IFindPathsToViews 
  {
    string find_path_for<ViewModel>();
  }
}