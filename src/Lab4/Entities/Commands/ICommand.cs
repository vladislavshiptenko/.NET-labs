using Itmo.ObjectOrientedProgramming.Lab4.Entities.Contexts;
using Itmo.ObjectOrientedProgramming.Lab4.Models.Outputs;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public interface ICommand
{
    public Output Execute(IContext context);
}