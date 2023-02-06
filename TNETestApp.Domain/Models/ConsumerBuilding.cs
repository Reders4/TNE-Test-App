using System.Collections.Generic;

namespace TNETestApp.Domain.Models
{
    public class ConsumerBuilding
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public int? SubsidiaryCompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual SubsidiaryCompany SubsidiaryCompany { get; set; }

        public virtual ICollection<MeasuringPoint> MeasuringPoints { get; set; }
        public virtual ICollection<DeliveryPoint> DeliveryPoints { get; set; }
    }
}
