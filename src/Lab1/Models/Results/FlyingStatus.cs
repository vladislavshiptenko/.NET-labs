namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Results;

public class FlyingStatus
{
    public FlyingStatus(FlyingStatusType statusType)
    {
        StatusType = statusType;
    }

    public enum FlyingStatusType
    {
        Success,
        ShipLoss,
        ShipDestroying,
        CrewLoss,
    }

    public FlyingStatusType StatusType { get; set; }
}