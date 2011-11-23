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
                departmentFinder = depends.on<IDepartmentFinder>();
            };

            Because b = () =>
                sut.process(request);

            It should_delegate_finding_the_main_departments_in_the_store = () =>
                departmentFinder.received(x => x.FindDepartments(request));

            static IDepartmentFinder departmentFinder;
            static IContainRequestInformation request;
        }
    }
}