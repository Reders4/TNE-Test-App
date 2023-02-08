using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TNETestApp.Domain.Enums;

namespace TNETestApp.Domain.Models
{
    public class VoltageTransformer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public double TransformerRatio { get; set; }
        [Required]
        public DateTime VerificationDate { get; set; }
        [Required]
        public DateTime OutOfVerificationDate { get; set; }
        [Required]
        public VoltageTransformerType TransformerType { get; set; }
        [Required]
        public int MeasuringPointId { get; set; }
        [ForeignKey(nameof(MeasuringPointId))]
        public virtual MeasuringPoint MeasuringPoint { get; set; }
    }
}
