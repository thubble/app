using app.web.application.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application
{
	public class ViewTheProductsInADepartment : IImplementAUseCase
	{
		IProductFinder product_finder;
		IDisplayReportModels response_gateway;

		public ViewTheProductsInADepartment(IDisplayReportModels response_gateway, IProductFinder product_finder)
		{
			this.response_gateway = response_gateway;
			this.product_finder = product_finder;
		}

		public ViewTheProductsInADepartment()
			: this(Stub.with<StubResponseEngine>(), Stub.with<StubProductFinder>())
		{
		}

		public void process(IContainRequestInformation request)
		{
			response_gateway.display(product_finder.get_the_products_in_a_department(request.map<Department>()));
		}
	}
}