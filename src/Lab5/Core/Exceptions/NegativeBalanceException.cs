namespace Core.Exceptions;

public class NegativeBalanceException : Exception
{
    public NegativeBalanceException(string name)
        : base(name)
    {
    }

    public NegativeBalanceException()
    {
    }

    public NegativeBalanceException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}