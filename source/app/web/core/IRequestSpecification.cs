namespace app.web.core
{
    public interface IRequestSpecification
    {
        bool meets_specifications(IContainRequestInformation request);
    }
}