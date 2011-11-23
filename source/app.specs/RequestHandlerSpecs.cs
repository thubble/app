using System.Collections.Generic;
using System.Linq;
using Machine.Specifications;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    public class RequestHandlerSpecs
    {
        [Subject(typeof(RequestHandler))]
        public class CommandRegistrySpecs
        {
            public abstract class concern : Observes<IProcessOneRequest,
                                                RequestHandler>
            {
            }

            public class when_checking_whether_a_command_can_handle_a_request : concern
            {
                public class and_can_handle : when_checking_whether_a_command_can_handle_a_request
                {
                    Establish c = () =>
                    {
                        request = fake.an<IContainRequestInformation>();
                        request_specification = depends.on<IRequestSpecification>();

                        request_specification.setup(x => x.meets_specifications(request)).Return(true);

                    };

                    Because b = () =>
                        result = sut.can_handle(request);


                    It should_return_true = () =>
                        result.ShouldBeTrue();

                    static IContainRequestInformation request;
                    static IRequestSpecification request_specification;
                    static bool result;
                }

                public class and_can_not_handle : when_checking_whether_a_command_can_handle_a_request
                {
                    Establish c = () =>
                    {
                        request = fake.an<IContainRequestInformation>();
                        request_specification = depends.on<IRequestSpecification>();

                        request_specification.setup(x => x.meets_specifications(request)).Return(false);

                    };

                    Because b = () =>
                        result = sut.can_handle(request);


                    It should_return_false = () =>
                        result.ShouldBeFalse();

                    static IContainRequestInformation request;
                    static IRequestSpecification request_specification;
                    static bool result;
                }
            }
        }
    }
}