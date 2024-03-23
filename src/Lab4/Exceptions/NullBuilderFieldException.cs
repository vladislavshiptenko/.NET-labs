using System;

namespace Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

public class NullBuilderFieldException : Exception
{
    public NullBuilderFieldException(string name)
        : base(name)
    {
    }

    public NullBuilderFieldException()
    {
    }

    public NullBuilderFieldException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}