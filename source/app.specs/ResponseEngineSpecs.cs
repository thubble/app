using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ResponseEngine))]
    public class ResponseEngineSpecs
    {
        public abstract class concern : Observes<IDisplayReportModels,
                                                    ResponseEngine>
        {
        }

        public class when_displayed : concern
        {
            Establish c = () =>
            {
                response_sender = depends.on<ISendAnHttpContext>();
                response_creater = depends.on<ICreateAnHttpContext>();

                http_context = fake.an<HttpContext>();

                report_view = fake.an<IEnumerable<Department>>();

                response_creater.setup(x => x.create_context(report_view)).Return(http_context);
            };

            Because b = () => sut.display(report_view);

            It should_create_an_http_request = () => response_creater.received(x => x.create_context(report_view));
            
            It should_send_an_http_response = () => response_sender.received(x => x.send_context(http_context));
                
            private static IEnumerable<Department> report_view;
            private static ISendAnHttpContext response_sender;
            private static ICreateAnHttpContext response_creater;
            private static HttpContext http_context;
        }
    }
}