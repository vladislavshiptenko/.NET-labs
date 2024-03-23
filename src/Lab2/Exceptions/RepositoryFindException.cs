using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

public class RepositoryFindException : Exception
{
    public RepositoryFindException(string name)
        : base(name)
    {
    }

    public RepositoryFindException()
    {
    }

    public RepositoryFindException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}