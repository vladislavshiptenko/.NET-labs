namespace Core.Exceptions;

public class EmptyQueryAnswerException : Exception
{
    public EmptyQueryAnswerException(string name)
        : base(name)
    {
    }

    public EmptyQueryAnswerException()
    {
    }

    public EmptyQueryAnswerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}