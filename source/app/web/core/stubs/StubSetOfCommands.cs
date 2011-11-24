using System.Collections;
using System.Collections.Generic;
using app.web.application;
using app.web.application.stubs;

namespace app.web.core.stubs
{
  public class StubSetOfCommands : IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return
        new RequestCommand(x => true, new ViewReport<IEnumerable<Department>>(new GetDepartmentsInDepartment()));
    }
  }

  public class GetDepartmentsInDepartment : IRunQuery<IEnumerable<Department>>
  {
    public IEnumerable<Department> run_using(IContainRequestInformation request)
    {
      return new StubFindInformationInTheStore().get_the_departments_in_a_department(request.map<Department>());
    }
  }

  public class GetTheMainDepartments : IRunQuery<IEnumerable<Department>>
  {
    public IEnumerable<Department> run_using(IContainRequestInformation request)
    {
      return new StubFindInformationInTheStore().get_the_main_departments();
    }
  }
}