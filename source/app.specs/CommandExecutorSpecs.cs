using System.Collections.Generic;
using Machine.Specifications;
using app.web.application;
using app.web.core;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
  [Subject(typeof(ViewReport<>))]
  public class CommandExecutorSpecs
  {
    public abstract class concern : Observes<ViewReport<IEnumerable<Department>>>
    {
    }

    public class when_run : concern
    {
      Establish c = () =>
      {
        request = fake.an<IContainRequestInformation>();
        parent_department = fake.an<Department>();
        departments = new List<Department> {new Department()};
        query = depends.on<IRunQuery<IEnumerable<Department>>>();
        response_engine = depends.on<IDisplayReportModels>();

        request.setup(x => x.map<Department>()).Return(parent_department);

        query.setup(x => x.run_using(request)).Return(departments);
      };

      Because b = () =>
        sut.process(request);

      It should_display_the_report_model = () =>
        response_engine.received(x => x.display(departments));

      static IRunQuery<IEnumerable<Department>> query;
      static IContainRequestInformation request;
      static IDisplayReportModels response_engine;
      static IEnumerable<Department> departments;
      static Department parent_department;
    }
  }
}