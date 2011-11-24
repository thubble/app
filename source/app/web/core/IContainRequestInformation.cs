namespace app.web.core
{
  public interface IContainRequestInformation
  {
		MappableType map<MappableType>();
		MappableType map<MappableType, MappableParentType>(MappableParentType parent);
  }
}