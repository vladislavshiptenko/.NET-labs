using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Hull;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public class Stella : SpaceShip
{
    public Stella(DeflectorPhotonic deflectorPhotonic)
        : base(new EnginePulseC(), new EngineJumpingOmega(), new DeflectorClassFirst(deflectorPhotonic), new HullClassFirst(), null, LittleWeight)
    {
    }
}