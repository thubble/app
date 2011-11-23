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
            };

            Because b = () =>
                sut.process(request);

            It should_get_the_main_departments_in_the_store = () =>
                department_finder.received(x => x.get_the_main_departments());

            static IDepartmentFinder department_finder;
            static IContainRequestInformation request;
        }
    }
}