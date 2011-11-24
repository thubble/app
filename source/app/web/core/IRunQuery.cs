namespace app.web.core
{
  public interface IRunQuery<out TResponse>
  {
    TResponse run_using(IContainRequestInformation request);
  }
}