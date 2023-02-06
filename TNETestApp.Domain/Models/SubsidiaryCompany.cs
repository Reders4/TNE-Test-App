using System.Collections.Generic;

namespace TNETestApp.Domain.Models
{
    public class SubsidiaryCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CompanyId { get; set; }


        public virtual Company Company { get; set; }
        public virtual ICollection<ConsumerBuilding> ConsumerBuildings { get; set; }
    }
}
