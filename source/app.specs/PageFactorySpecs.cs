using System.Web;
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
				the_page = fake.an<IDisplayA<OurViewModel>>();
				the_page_path = "asfasfsa.aspx";
				the_model = new OurViewModel();

				page_path_registry = depends.on<IFindPathsToViews>();
				depends.on<TemplateFactory>((path, type) =>
				{
					path.ShouldEqual(the_page_path);
					type.ShouldEqual(typeof(IDisplayA<OurViewModel>));
					return the_page;
				});

				page_path_registry.setup(x => x.find_path_for<OurViewModel>()).Return(the_page_path);
			};

			Because b = () =>
				result = sut.create_using(the_model);

			It should_populate_the_template_with_its_data = () =>
				the_page.model.ShouldEqual(the_model);

			It should_create_the_page_for_the_model = () =>
				result.ShouldEqual(the_page);

			static IFindPathsToViews page_path_registry;
			static OurViewModel the_model;
			static string the_page_path;
			static IDisplayA<OurViewModel> the_page;
			static IHttpHandler result;
		}

		public class OurViewModel
		{
		}
	}
}