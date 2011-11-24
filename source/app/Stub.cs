using System;

namespace app
{
  public class Stub
  {
    public static T with<T>(IConstrainStubBehaviour constraint) where T : new()
    {
      if (constraint.is_met()) return new T();

      throw new StubConstraintException();
    }

    public class NoConstraints : IConstrainStubBehaviour
    {
      public bool is_met()
      {
        return true;
      }
    }

    public interface IConstrainStubBehaviour
    {
      bool is_met();
    }

    public static T with<T>() where T : new()
    {
      return with<T>(new NoConstraints());
    }
  }

  public class StubConstraintException : Exception
  {
  }
}