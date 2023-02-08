using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNETestApp.Domain.Models
{
    public class ConsumerBuilding
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int CompanyId { get; set; }
        public int? SubsidiaryCompanyId { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public virtual Company Company { get; set; }
        [ForeignKey(nameof(SubsidiaryCompanyId))]
        public virtual SubsidiaryCompany SubsidiaryCompany { get; set; }

        public virtual ICollection<MeasuringPoint> MeasuringPoints { get; set; }
        public virtual ICollection<DeliveryPoint> DeliveryPoints { get; set; }
    }
}
