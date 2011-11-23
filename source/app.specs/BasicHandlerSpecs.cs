 using System.Web;
 using Machine.Specifications;
 using app.specs.utility;
 using app.web.core;
 using developwithpassion.specifications.rhinomocks;
 using developwithpassion.specifications.extensions;

namespace app.specs
{  
  [Subject(typeof(BasicHandler))]  
  public class BasicHandlerSpecs
  {
    public abstract class concern : Observes<IHttpHandler,
                                      BasicHandler>
    {
        
    }

   
    public class when_processing_an_http_context : concern
    {
      Establish c = () =>
      {
        front_controller = depends.on<IProcessRequests>();
        request_factory = depends.on<ICreateRequests>();

        a_request = fake.an<IContainRequestInformation>();
        the_context = ObjectFactory.web.create_http_context();

        request_factory.setup(x => x.create_from(the_context)).Return(a_request);
      };

      Because b = () =>
        sut.ProcessRequest(the_context);


      It should_delegate_processing_of_a_request_to_the_front_controller = () =>
        front_controller.received(x => x.process(a_request));

      static IProcessRequests front_controller;
      static IContainRequestInformation a_request;
      static HttpContext the_context;
      static ICreateRequests request_factory;
    }
  }
}
