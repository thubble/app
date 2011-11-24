using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheProductsInADepartment))]
	public class ViewTheProductsInADepartmentSpecs
  {
	public abstract class concern : Observes<IImplementAUseCase,
									  ViewTheProductsInADepartment>
	{
	}

	public class when_run : concern
	{
	  Establish c = () =>
	  {
	  	department = fake.an<Department>();
		request = fake.an<IContainRequestInformation>();
		products = new List<Product> {new Product()};
		product_finder = depends.on<IProductFinder>();
		response_engine = depends.on<IDisplayReportModels>();
		request.setup(x => x.map<Department>()).Return(department);

		product_finder.setup(x => x.get_the_products_in_a_department(department)).Return(products);
	  };

	  Because b = () =>
		sut.process(request);

	  It should_get_the_products_in_a_department = () =>
		product_finder.received(x => x.get_the_products_in_a_department(department));

	  It should_display_the_report_model = () =>
		response_engine.received(x => x.display(products));

	  static IProductFinder product_finder;
	  static IContainRequestInformation request;
	  static IDisplayReportModels response_engine;
	  static IEnumerable<Product> products;
	  static Department department;
	}
  }
}