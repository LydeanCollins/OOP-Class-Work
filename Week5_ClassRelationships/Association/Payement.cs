using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public abstract class Payement : Ipayement
    {
        protected Payement()
        {
            Tax = 0.18;
        }
        public DateTime BoughtOn { get; set; }

        public double Tax { get; set; }

        public abstract double Buy(Seat s);
    }
}
