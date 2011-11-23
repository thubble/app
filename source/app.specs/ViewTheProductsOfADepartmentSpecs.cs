using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheProductsOfADepartments))]
  public class ViewTheProductsOfADepartmentSpecs
  {
    public abstract class concern : Observes<IImplementAUseCase,
									  ViewTheProductsOfADepartments>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        products = new List<Product> {new Product()};
        department_finder = depends.on<IDepartmentFinder>();
        response_engine = depends.on<IDisplayReportModels>();
        request.setup(x => x.map<Department>()).Return(parent_department);

        department_finder.setup(x => x.get_the_products_in_a_department(parent_department)).Return(products);
      };

      Because b = () =>
        sut.process(request);

	  It should_get_the_departments_in_a_department = () =>
		 department_finder.received(x => x.get_the_products_in_a_department(parent_department));

      It should_display_the_report_model = () =>
        response_engine.received(x => x.display(products));

      static IDepartmentFinder department_finder;
      static IContainRequestInformation request;
      static IDisplayReportModels response_engine;
      static IEnumerable<Product> products;
      static Department parent_department;
    }
  }
}