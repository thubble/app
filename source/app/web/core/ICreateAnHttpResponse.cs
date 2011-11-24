using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace app.web.core
{
    public interface ICreateAnHttpResponse
    {
        HttpResponse create_response<ReportModel>(ReportModel model);
    }
}
