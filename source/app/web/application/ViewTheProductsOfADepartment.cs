using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application
{
    public class ViewTheProductsOfADepartments : IImplementAUseCase
    {
        IDepartmentFinder department_finder;
        IDisplayReportModels response_gateway;

        public ViewTheProductsOfADepartments(IDisplayReportModels response_gateway, IDepartmentFinder department_finder)
        {
            this.response_gateway = response_gateway;
            this.department_finder = department_finder;
        }

		public ViewTheProductsOfADepartments()
            : this(new StubResponseEngine(), new StubDepartmentFinder())
        {
        }

        public void process(IContainRequestInformation request)
        {
            response_gateway.display(department_finder.get_the_products_in_a_department(request.map<Department>()));
        }
    }
}