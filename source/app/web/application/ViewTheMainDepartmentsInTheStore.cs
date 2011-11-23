using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application
{
  public class ViewTheMainDepartmentsInTheStore :IImplementAUseCase
  {
    IDepartmentFinder department_finder;
    IDisplayReportModels response_gateway;

    public ViewTheMainDepartmentsInTheStore(IDisplayReportModels response_gateway, IDepartmentFinder department_finder)
    {
      this.response_gateway = response_gateway;
      this.department_finder = department_finder;
    }

    public ViewTheMainDepartmentsInTheStore():this(new StubResponseEngine(),new StubDepartmentFinder())
    {
    }

    public void process(IContainRequestInformation request)
    {
      response_gateway.display(department_finder.get_the_main_departments());
    }
  }
}