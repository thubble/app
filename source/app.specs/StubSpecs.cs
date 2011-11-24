using Machine.Specifications;
using app.web.core.stubs;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(Stub))]
  public class StubSpecs
  {
    public abstract class concern : Observes
    {
    }

    public class when_a_stub_is_requested : concern
    {
      Because b = () =>
        result = Stub.with<TestStub>();

      It should_return_a_stub_of_the_same_type_it_was_called_with = () =>
        result.ShouldBeAn<TestStub>();

      static object result;
    }
  }
}