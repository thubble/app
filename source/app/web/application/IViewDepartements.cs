using System.Collections.Generic;

namespace app.web.application
{
    public interface IViewDepartements
    {
        void view_departments(IEnumerable<Department> main_departments);
    }
}