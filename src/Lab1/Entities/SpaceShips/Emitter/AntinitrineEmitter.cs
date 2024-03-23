namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Emitter;

public class AntinitrineEmitter
{
    private const int StartLimitUse = 10;

    public int LimitUse { get; private set; } = StartLimitUse;

    public void Use()
    {
        if (LimitUse != 0)
        {
            LimitUse--;
        }
    }
}