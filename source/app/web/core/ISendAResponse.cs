using System.Web;

namespace app.web.core
{
    public interface ISendAResponse
    {
        void send_response_using<ResponseType>(ResponseType response);
    }
}