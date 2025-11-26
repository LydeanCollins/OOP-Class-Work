using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public class BlackFridayPayement : Payement
    {
        public BlackFridayPayement() : base()
        {
            Discount = 0.20;
        }

        public double Discount { get; set; }
        public override double Buy(Seat s)
        {
            return (s.price * (1 - Discount)) * (1 + Tax);
        }
    }
}
