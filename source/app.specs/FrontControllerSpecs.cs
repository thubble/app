 using Machine.Specifications;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(FrontController))]  
  public class FrontControllerSpecs
  {
    public abstract class concern : Observes<IProcessRequests,
                                      FrontController>
    {
        
    }

   
    public class when_processing_a_request : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        command_that_can_process = fake.an<IProcessOneRequest>();
        command_registry = depends.on<IFindCommands>();

        command_registry.setup(x => x.get_the_command_that_can_process(request)).Return(command_that_can_process);
      };

      Because b = () =>
        sut.process(request);

      It should_delegate_the_processing_to_the_command_that_can_process = () =>
        command_that_can_process.received(x => x.process(request));

      static IProcessOneRequest command_that_can_process;
      static IContainRequestInformation request;
      static IFindCommands command_registry;
    }
  }
}
