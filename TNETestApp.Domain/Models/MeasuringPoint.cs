using System.Collections.Generic;

namespace TNETestApp.Domain.Models
{
    public class MeasuringPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ConsumerBuildingId { get; set; }

        public virtual ConsumerBuilding ConsumerBuilding { get; set; }
        public virtual ElectricityMeter ElectricityMeter { get; set; }
        public virtual CurrentTransformer CurrentTransformer { get; set; }
        public virtual VoltageTransformer VoltageTransformer { get; set; }
        public virtual ICollection<MeteringDevice> MeteringDevices { get; set; }
    }
}
