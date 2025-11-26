using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week5_ClassRelationships.Association
{
    public class Ticket
    {
        public Event Event { get; set; }
        public Seat Seat { get; set; }
        public User User { get; set; }
        public Ticket(Event e, Seat s, User u)
        {
            Event = e;
            Seat = s;
            User = u;
        }
        public List<Seat> Seats { get; set; }

        //1. Relationship between Ticket and Payement is the weakest one: Association
        //2. Association: Class A is being used by Class B BUT not store it in any of the attributes inside 
        //3. (Strongest -> Weakest) Composition -> Aggregation -> Association
        //4.
        public void sellTicket(Payement payement)
        {
            Console.WriteLine($"you need yo pay this Amount: {payement.Buy(Seat)}");
            //Once payement is successful mark the seat as booked

        }
    }
}
