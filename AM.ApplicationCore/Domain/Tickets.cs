using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AM.ApplicationCore.Domain
{
   //Annotation  [PrimaryKey("FlightFK", "PassengerFK")]
    public class Tickets
    {
        public double Prix { get; set; }
        public string Siege { get; set; }

        public bool VIP { get; set; }

        public int FlightFK { get; set; }
        public virtual Flight Flight { get; set; }

        public string PassengerFK { get; set; }
        public virtual Passenger Passenger { get; set; }
    }
}
