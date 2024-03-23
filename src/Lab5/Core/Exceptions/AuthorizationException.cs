namespace Core.Exceptions;

public class AuthorizationException : Exception
{
    public AuthorizationException(string name)
        : base(name)
    {
    }

    public AuthorizationException()
    {
    }

    public AuthorizationException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}