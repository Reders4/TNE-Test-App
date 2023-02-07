using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNETestApp.Domain.Models
{
    public class MeteringDevice
    {
        [Required]
        public int MeasuringPointId { get; set; }
        [Required]
        public int DeliveryPointId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [ForeignKey("MeasuringPointId")]
        public virtual MeasuringPoint MeasuringPoint { get; set; }
        [ForeignKey("DeliveryPointId")]
        public virtual DeliveryPoint DeliveryPoint { get; set; }

    }
}
