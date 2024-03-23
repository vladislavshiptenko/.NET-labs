using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class PleasureShuttle : SpaceShip
{
    public PleasureShuttle()
        : base(new EnginePulseC(), null, null, new HullClassFirst(), null, LittleWeight)
    {
    }
}