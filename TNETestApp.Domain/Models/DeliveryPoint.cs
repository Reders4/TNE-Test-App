using System.Collections.Generic;

namespace TNETestApp.Domain.Models
{
    public class DeliveryPoint
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MaxPower { get; set; }
        public int ConsumerBuildingId { get; set; }

        public virtual ConsumerBuilding ConsumerBuilding { get; set; }
        public virtual ICollection<MeteringDevice> MeteringDevices { get; set; }
    }
}
