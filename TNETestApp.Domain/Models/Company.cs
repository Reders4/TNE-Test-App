using System.Collections.Generic;

namespace TNETestApp.Domain.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<SubsidiaryCompany> SubsidiaryCompanys { get;set; }
        public virtual ICollection<ConsumerBuilding> ConsumerBuildings { get;set; }
    }
}
