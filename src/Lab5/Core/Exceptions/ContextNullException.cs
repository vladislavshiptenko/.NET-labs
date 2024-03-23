namespace Core.Exceptions;

public class ContextNullException : Exception
{
    public ContextNullException(string name)
        : base(name)
    {
    }

    public ContextNullException()
    {
    }

    public ContextNullException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}