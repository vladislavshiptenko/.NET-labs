using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Vaklas : SpaceShip
{
    public Vaklas(DeflectorPhotonic deflectorPhotonic)
        : base(new EnginePulseE(), new EngineJumpingGamma(), new DeflectorClassSecond(deflectorPhotonic), new HullClassSecond(), null, MiddleWeight)
    {
    }
}