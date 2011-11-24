namespace app
{
	public class StubFactory
	{
		public static T with<T>() where T:new()
		{
			return new T();
		}
	}
}