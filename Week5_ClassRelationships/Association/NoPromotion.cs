using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public class NoPromotion : Payement
    {
        public override double Buy(Seat s)
        {
           return s.price * (1 + Tax);
        }
    }
}
