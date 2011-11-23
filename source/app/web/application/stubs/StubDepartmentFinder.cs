using System.Collections.Generic;
using System.Linq;

namespace app.web.application.stubs
{
  public class StubDepartmentFinder:IDepartmentFinder
  {
    public IEnumerable<Department> get_the_main_departments()
    {
      return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Department 0")});
    }
  }
}