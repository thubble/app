using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewTheDepartmentsOfADepartment))]
  public class ViewTheDepartmentsOfADepartmentSpecs
  {
    public abstract class concern : Observes<IImplementAUseCase,
                                      ViewTheDepartmentsOfADepartment>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        departments = new List<Department> {new Department()};
        find_information_in_the_store = depends.on<IFindInformationInTheStore>();
        response_engine = depends.on<IDisplayReportModels>();
        request.setup(x => x.map<Department>()).Return(parent_department);

        find_information_in_the_store.setup(x => x.get_the_departments_in_a_department(parent_department)).Return(departments);
      };

      Because b = () =>
        sut.process(request);

      It should_get_the_departments_in_a_department = () =>
        find_information_in_the_store.received(x => x.get_the_departments_in_a_department(parent_department));

      It should_display_the_report_model = () =>
        response_engine.received(x => x.display(departments));

      static IFindInformationInTheStore find_information_in_the_store;
      static IContainRequestInformation request;
      static IDisplayReportModels response_engine;
      static IEnumerable<Department> departments;
      static Department parent_department;
    }
  }
}