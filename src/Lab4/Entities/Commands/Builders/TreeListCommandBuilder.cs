using Itmo.ObjectOrientedProgramming.Lab4.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands.Builders;

public class TreeListCommandBuilder : ICommandBuilder
{
    private int _depth;

    public void WithDepth(int depth)
    {
        if (depth <= 0)
        {
            throw new NegativeIntException(nameof(depth));
        }

        _depth = depth;
    }

    public ICommand Build()
    {
        if (_depth <= 0)
        {
            throw new NegativeIntException(nameof(_depth));
        }

        return new TreeListCommand(_depth);
    }
}