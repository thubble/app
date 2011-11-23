using app.web.core;

namespace app.specs
{
    public interface IDepartmentFinder
    {
        void FindDepartments(IContainRequestInformation request);
    }
}