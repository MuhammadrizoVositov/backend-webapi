namespace WebSite.Persistance.Exeptions;

public class NotFoundException : AppException
{
    private const string MESSAGE = "the {0} not found with {1}";

    public NotFoundException(string message)
        : base(message)
    {
    }

    public NotFoundException(string resourceName, object resourceKey)
        : base(MESSAGE, resourceName, resourceKey)
    {
    }
}
