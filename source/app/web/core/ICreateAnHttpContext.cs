using System.Web;

namespace app.web.core
{
    public interface ICreateAnHttpContext
    {
        HttpContext create_context<ReportModel>(ReportModel model);
    }
}
