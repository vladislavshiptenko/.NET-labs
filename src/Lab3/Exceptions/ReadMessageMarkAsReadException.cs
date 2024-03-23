using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

public class ReadMessageMarkAsReadException : Exception
{
    public ReadMessageMarkAsReadException(string name)
        : base(name)
    {
    }

    public ReadMessageMarkAsReadException()
    {
    }

    public ReadMessageMarkAsReadException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}