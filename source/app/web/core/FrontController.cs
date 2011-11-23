namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
      IFindCommands CommandFinder; 

      public FrontController(IFindCommands finder)
      {
          this.CommandFinder = finder;
      }
    public void process(IContainRequestInformation a_request)
    {
        this.CommandFinder.get_the_command_that_can_process(a_request).process(a_request);
    }
  }
}