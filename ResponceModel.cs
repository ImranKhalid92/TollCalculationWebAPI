using System.Collections.Generic;

namespace TollCalculation.Models
{
    public class ResponceModel
    {
        public bool OperationSuccess { get; set; } = true;
        public double BaseRate { get; set; }
        public double DistanceCost { get; set; }
        public double SubTotal { get; set; }
        
        public double Discount { get; set; }
        public double TotalToBeCharged { get; set; }
   
     

    }
}
