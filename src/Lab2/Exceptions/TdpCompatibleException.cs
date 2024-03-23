using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class TdpCompatibleException : WarningException
{
    public TdpCompatibleException(string name)
        : base(name)
    {
    }

    public TdpCompatibleException()
    {
    }

    public TdpCompatibleException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}