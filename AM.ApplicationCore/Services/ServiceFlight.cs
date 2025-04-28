using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : Service<Flight>, IServiceFlight
    {
        public ServiceFlight(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public bool CanReserveSeats(Flight flight, int n)
        {
            var plane = flight.Plane;
            int Capacity = flight.Plane.Capacity;
            int nbPassengers = flight.Tickets.Count;

            return Capacity >= (nbPassengers + n);
        }



         

    }
}
