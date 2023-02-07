using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNETestApp.Domain.Models
{
    public class MeasuringPoint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int ConsumerBuildingId { get; set; }
        [ForeignKey("ConsumerBuildingId")]
        public virtual ConsumerBuilding ConsumerBuilding { get; set; }
        public virtual ElectricityMeter ElectricityMeter { get; set; }
        public virtual CurrentTransformer CurrentTransformer { get; set; }
        public virtual VoltageTransformer VoltageTransformer { get; set; }
        public virtual ICollection<MeteringDevice> MeteringDevices { get; set; }
    }
}
