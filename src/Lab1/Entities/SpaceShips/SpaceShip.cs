using System;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Armors.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Emitter;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips.Engines;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.SpaceShips;

public abstract class SpaceShip
{
    protected const double LittleWeight = 1.0;
    protected const double MiddleWeight = 1.25;
    protected const double HeavyWeight = 1.5;
    protected SpaceShip(EnginePulse? enginePulse, EngineJumping? engineJumping, DeflectorBase? deflector, ArmorBase armor, AntinitrineEmitter? antinitrineEmitter, double weight)
    {
        EnginePulse = enginePulse;
        EngineJumping = engineJumping;
        Deflector = deflector;
        Armor = armor;
        Weight = weight;
        AntinitrineEmitter = antinitrineEmitter;
    }

    public double Weight { get; }
    public DeflectorBase? Deflector { get; }
    public AntinitrineEmitter? AntinitrineEmitter { get; }
    public ArmorBase Armor { get; }
    public EnginePulse? EnginePulse { get; }
    public EngineJumping? EngineJumping { get; }
    public bool IsCrewLoss { get; private set; }

    public void KillCrew()
    {
        IsCrewLoss = true;
    }

    public void Fly(EnvironmentBase environment)
    {
        if (environment is null)
        {
            throw new ArgumentNullException(nameof(environment));
        }

        EnginePulse?.Fly(environment);
        EngineJumping?.Fly(environment);

        environment.ObstaclesAttack(this);
    }
}