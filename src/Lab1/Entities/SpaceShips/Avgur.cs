using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Avgur : SpaceShip
{
    public Avgur(DeflectorPhotonic deflectorPhotonic)
        : base(new EnginePulseE(), new EngineJumpingAlpha(), new DeflectorClassThird(deflectorPhotonic), new HullClassThird(), null, HeavyWeight)
    {
    }
}