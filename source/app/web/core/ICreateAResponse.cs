using System.Web;

namespace app.web.core
{
    public interface ICreateAResponse<ResponseType>
    {
        ResponseType create_using<ReportModel>(ReportModel model);
    }
}
