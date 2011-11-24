using System.Web;

namespace app.web.core
{
    public class WebResponseEngine : IDisplayReportModels
    {
        private ISendAResponse response_sender;
        private ICreateAResponse<HttpContext> response_creator;
        private HttpContext context;

        public WebResponseEngine(ISendAResponse responseSender, ICreateAResponse<HttpContext> responseCreator)
        {
            response_sender = responseSender;
            response_creator = responseCreator;
        }

        public void display<ReportModel>(ReportModel model)
        {
            context = response_creator.create_using(model);
            response_sender.send_response_using(context);
        }
    }
}