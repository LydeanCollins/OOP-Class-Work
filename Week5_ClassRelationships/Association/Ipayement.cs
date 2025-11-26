using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public interface Ipayement
    {
        DateTime BoughtOn { get; set; }
        double Buy(Seat s);
    }
}
