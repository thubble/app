using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(WebResponseEngine))]
  public class WebResponseEngineSpecs
  {
    public abstract class concern : Observes<IDisplayReportModels,
                                      WebResponseEngine>
    {
    }

    public class when_displayed : concern
    {
      Establish c = () =>
      {
        response = fake.an<IHttpHandler>();
        response_factory = depends.on<ICreateAResponse>();
        http_context = ObjectFactory.web.create_http_context();
        depends.on<CurrentContextResolver>(() => http_context);
        depends.on(http_context);
        view_model = fake.an<IEnumerable<AViewModel>>();
        response_factory.setup(x => x.create_using(view_model)).Return(response);
      };

      Because b = () => sut.display(view_model);


      It should_process_the_response = () => 
        response.received(x => x.ProcessRequest(http_context));

      static IEnumerable<AViewModel> view_model;
      static ICreateAResponse response_factory;
      static HttpContext http_context;
      static IHttpHandler response;
    }

    public class AViewModel
    {
    }
  }
}