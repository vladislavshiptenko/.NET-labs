namespace Core.Exceptions;

public class SameUsernameException : Exception
{
    public SameUsernameException(string name)
        : base(name)
    {
    }

    public SameUsernameException()
    {
    }

    public SameUsernameException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}