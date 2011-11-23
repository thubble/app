using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application
{
  public class ViewTheMainDepartmentsInTheStore :IImplementAUseCase
  {
    IFindInformationInTheStore find_information_in_the_store;
    IDisplayReportModels response_gateway;

    public ViewTheMainDepartmentsInTheStore(IDisplayReportModels response_gateway, IFindInformationInTheStore find_information_in_the_store)
    {
      this.response_gateway = response_gateway;
      this.find_information_in_the_store = find_information_in_the_store;
    }

    public ViewTheMainDepartmentsInTheStore():this(new StubResponseEngine(),new StubFindInformationInTheStore())
    {
    }

    public void process(IContainRequestInformation request)
    {
      response_gateway.display(find_information_in_the_store.get_the_main_departments());
    }
  }
}