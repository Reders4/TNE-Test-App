using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TNETestApp.Domain.Models
{
    public class Company
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }

        public virtual ICollection<SubsidiaryCompany> SubsidiaryCompanys { get;set; }
        public virtual ICollection<ConsumerBuilding> ConsumerBuildings { get;set; }
    }
}
