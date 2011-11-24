using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(WebResponseEngine))]
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<IDisplayReportModels,
                                                    WebResponseEngine>
        {
        }

        public class when_displayed : concern
        {
            Establish c = () =>
            {
                response_sender = depends.on<ISendAResponse>();
                response_creater = depends.on<ICreateAResponse<HttpContext>>();

                http_context = ObjectFactory.web.create_http_context();

                report_view = fake.an<IEnumerable<Department>>();

                response_creater.setup(x => x.create_using(report_view)).Return(http_context);
            };

            Because b = () => sut.display(report_view);

            It should_create_an_http_request = () => response_creater.received(x => x.create_using(report_view));
            
            It should_send_an_http_response = () => response_sender.received(x => x.send_response_using(http_context));
                
            private static IEnumerable<Department> report_view;
            private static ISendAResponse response_sender;
            private static ICreateAResponse<HttpContext>  response_creater;
            private static HttpContext http_context;
        }
    }
}