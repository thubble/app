namespace app.web.core.stubs
{
  public class StubMissingCommand:IProcessOneRequest
  {
    public void process(IContainRequestInformation request)
    {

    }

    public bool can_handle(IContainRequestInformation request)
    {
      return false;
    }
  }
}