using System.Collections;
using System.Collections.Generic;
using app.web.application;

namespace app.web.core.stubs
{
  public class StubSetOfCommands:IEnumerable<IProcessOneRequest>
  {
    IEnumerator IEnumerable.GetEnumerator()
    {
      return GetEnumerator();
    }

    public IEnumerator<IProcessOneRequest> GetEnumerator()
    {
      yield return new RequestCommand(x => true, new ViewTheDepartmentsOfADepartment());
      yield return new RequestCommand(x => true, new ViewTheMainDepartmentsInTheStore());
      yield return new RequestCommand(x => true, new ViewTheProductsOfADepartment());
    }

  }
}