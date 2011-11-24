using System.Web;

namespace app.web.core
{
    public interface ISendAnHttpContext
    {
        void send_context(HttpContext context);
    }
}