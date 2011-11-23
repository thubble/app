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
                departments = new List<Department> { new Department() };
                department_finder = depends.on<IDepartmentFinder>();
                response_engine = depends.on<IDisplayReportModels>();

                department_finder.setup(x => x.get_the_departments_in_a_department(request.Department)).Return(departments);
            };

            Because b = () =>
              sut.process(request);

            It should_get_the_departments_in_a_department = () =>
              department_finder.received(x => x.get_the_departments_in_a_department(request.Department));

            It should_display_the_report_model = () =>
              response_engine.received(x => x.display(departments));

            static IDepartmentFinder department_finder;
            static IContainRequestInformation request;
            static IDisplayReportModels response_engine;
            static IEnumerable<Department> departments;
        }
    }
}