using System.Collections.Generic;
using System.Web;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(DisplayReportModel))]
    public class DisplayReportModelSpecs
    {
        public abstract class concern : Observes<IDisplayReportModels,
                                                    DisplayReportModel>
        {
        }

        public class when_displayed : concern
        {
            Establish c = () =>
            {
                response_sender = depends.on<ISendAnHttpResponse>();
                response_creater = depends.on<ICreateAnHttpResponse>();

                httpResponse = fake.an<HttpResponse>();

                report_view = fake.an<IEnumerable<Department>>();

                response_creater.setup(x => x.create_response(report_view)).Return(httpResponse);
            };

            Because b = () => sut.display(report_view);

            It should_create_an_http_request = () => response_creater.received(x => x.create_response(report_view));
            It should_send_an_http_response = () => response_sender.received(x => x.send_response(httpResponse));
                
            private static IEnumerable<Department> report_view;
            private static ISendAnHttpResponse response_sender;
            private static ICreateAnHttpResponse response_creater;
            private static HttpResponse httpResponse;
        }
    }
}