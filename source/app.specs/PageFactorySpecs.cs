using Machine.Specifications;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(PageFactory))]
  public class PageFactorySpecs
  {
    public abstract class concern : Observes<ICreateAResponse,
                                      PageFactory>
    {
    }

    public class when_creating_the_page_that_can_display_a_view_model : concern
    {
      Establish c = () =>
      {
        the_model = new OurViewModel();
        page_path_registry = depends.on<IFindPathsToViews>();
      };
      Because b = () =>
        sut.create_using(the_model);


      It should_get_the_path_to_the_page_that_can_display_the_view_model = () =>
        page_path_registry.received(x => x.find_path_for<OurViewModel>());

      static IFindPathsToViews page_path_registry;
      static OurViewModel the_model;
    }

    public class OurViewModel
    {
    }
  }
}