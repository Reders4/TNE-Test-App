using System;

namespace TNETestApp.Domain.Models
{
    public class MeteringDevice
    {
        public int MeasuringPointId { get; set; }
        public int DeliveryPointId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public virtual MeasuringPoint MeasuringPoint { get; set; }
        public virtual DeliveryPoint DeliveryPoint { get; set; }

    }
}
