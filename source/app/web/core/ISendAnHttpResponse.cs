using System.Web;

namespace app.web.core
{
    public interface ISendAnHttpResponse
    {
        void send_response(HttpResponse response);
    }
}