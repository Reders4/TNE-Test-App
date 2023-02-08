namespace TNETestApp.Services.MeasuringPoints.Commands
{
    public record CreateMeasuringPointCommand(string Name, int ConsumerBuildingId, int ElectricityMeterId, int CurrentTransformerId, int VoltageTransformerId)
    {
    }
}
