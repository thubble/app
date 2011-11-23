namespace app.web.core
{
  public class FrontController : IProcessRequests
  {
    IFindCommands command_registry;

    public FrontController(IFindCommands registry)
    {
      this.command_registry = registry;
    }

    public void process(IContainRequestInformation a_request)
    {
      this.command_registry.get_the_command_that_can_process(a_request).process(a_request);
    }
  }
}