namespace app.web.core
{
  public class RequestCommand : IProcessOneRequest
  {
    RequestMatch matcher;
    IImplementAUseCase application_behaviour;

    public RequestCommand(RequestMatch matcher, IImplementAUseCase application_behaviour)
    {
      this.matcher = matcher;
      this.application_behaviour = application_behaviour;
    }

    public void process(IContainRequestInformation request)
    {
      application_behaviour.process(request);
    }

    public bool can_handle(IContainRequestInformation request)
    {
      return matcher(request);
    }
  }
}