using System;
using TNETestApp.Domain.Enums;

namespace TNETestApp.Domain.Models
{
    public class VoltageTransformer
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public double TransformerRatio { get; set; }
        public DateTime VerificationDate { get; set; }
        public DateTime OutOfVerificationDate { get; set; }
        public VoltageTransformerType TransformerType { get; set; }
        public int MeasuringPointId { get; set; }

        public virtual MeasuringPoint MeasuringPoint { get; set; }
    }
}
