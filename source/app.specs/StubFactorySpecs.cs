using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using app.web.core.stubs;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(StubFactory))]
  public class StubFactorySpecs
  {
    public abstract class concern : Observes<StubFactory>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        //request = fake.an<IContainRequestInformation>();
		//departments = new List<Department> {new Department()};
		//find_information_in_the_store = depends.on<IFindInformationInTheStore>();
		//response_engine = depends.on<IDisplayReportModels>();
		//request.setup(x => x.map<Department>()).Return(parent_department);

		//find_information_in_the_store.setup(x => x.get_the_departments_in_a_department(parent_department)).Return(departments);
      };

      Because b = () =>
        result = StubFactory.with<TestStub>();

    	private It should_return_a_stub_of_the_same_type_it_was_called_with = () =>
			result.ShouldBeOfType<TestStub>();

    	private static object result;

    	//It should_display_the_report_model = () =>
    	//  response_engine.received(x => x.display(departments));

    }
  }
}