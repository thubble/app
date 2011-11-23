using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  public class RequestCommandSpecs
  {
    public abstract class concern : Observes<IProcessOneRequest,
                                      RequestCommand>
    {
    }

    public class when_determining_if_it_can_handle_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        depends.on<RequestMatch>(x => true);
      };

      Because b = () =>
        result = sut.can_handle(request);

      It should_make_the_determination_by_using_its_request_matcher = () =>
        result.ShouldBeTrue();

      static IContainRequestInformation request;
      static bool result;
    }

    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        application_behaviour  = depends.on<IImplementAUseCase>();
      };

      Because b = () =>
        sut.process(request);


      It should_delegate_processing_to_the_application_behaviour = () =>
        application_behaviour.received(x => x.process(request));

      static IContainRequestInformation request;
      static IImplementAUseCase application_behaviour;
    }
  }
}