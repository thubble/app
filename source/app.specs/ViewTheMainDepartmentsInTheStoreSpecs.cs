using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof(ViewTheMainDepartmentsInTheStore))]
    public class ViewTheMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<IImplementAUseCase,
                                          ViewTheMainDepartmentsInTheStore>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
                department_finder = depends.on<IDepartmentFinder>();
                department_viewer = depends.on<IViewDepartements>();

                department_finder.setup(x => x.get_the_main_departments()).Return(main_departments);
            };

            Because b = () =>
                sut.process(request);

            It should_get_the_main_departments_in_the_store = () =>
                department_finder.received(x => x.get_the_main_departments());

            It should_delegate_viewing_the_departments = () =>
                department_viewer.received(x => x.view_departments(main_departments));

            static IDepartmentFinder department_finder;
            static IContainRequestInformation request;
            private static IViewDepartements department_viewer;
            private static IEnumerable<Department> main_departments;
        }
    }
}