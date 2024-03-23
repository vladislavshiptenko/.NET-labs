namespace Core.Exceptions;

public class LoginException : Exception
{
    public LoginException(string name)
        : base(name)
    {
    }

    public LoginException()
    {
    }

    public LoginException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}