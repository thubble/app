using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
	[Subject(typeof(BasicRequestFactory))]
	public class BasicRequestFactorySpecs
	{
		public abstract class concern : Observes<ICreateRequests,
																			BasicRequestFactory>
		{

		}


		public class when_creating_a_request_from_an_http_context : concern
		{
			Establish c = () =>
			{
				request_path_mapper = depends.on<IMapRequestsToPaths>();

				a_request = fake.an<IContainRequestInformation>();
				the_context = new HttpContext(new HttpRequest("FILENAME", "URL", "QUERY"), new HttpResponse(null));

				//request_path_mapper.setup(x => x.get_request_that_can_handle_path("URL")).Return(a_request);
			};

			private Because b = () =>
				result = sut.create_from(the_context);


			It should_delegate_finding_request_to_registry = () =>
				request_path_mapper.received(x => x.get_request_that_can_handle_path("URL"));

			static IMapRequestsToPaths request_path_mapper;
			static IContainRequestInformation result;
			static HttpContext the_context;
			static IContainRequestInformation a_request;
		}
	}
}
