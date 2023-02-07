using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNETestApp.Domain.Models
{
    public class DeliveryPoint
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MaxPower { get; set; }
        [Required]
        public int ConsumerBuildingId { get; set; }
        [ForeignKey("ConsumerBuildingId")]
        public virtual ConsumerBuilding ConsumerBuilding { get; set; }
        public virtual ICollection<MeteringDevice> MeteringDevices { get; set; }
    }
}
