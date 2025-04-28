using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;


namespace AM.ApplicationCore.Services
{
    public class ServicePlane : Service<Plane>, IServicePlane
    {
        public ServicePlane(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }


        public IList<Passenger> GetPassengersByPlane(Plane plane)
        {
            return GetById(plane.PlaneId).Flights
                .SelectMany(f => f.Tickets.Select(t => t.Passenger))
                .ToList();
        }



        public IList<Flight> GetFlights(int n)
        {
            return GetAll()
                  .OrderByDescending(p => p.PlaneId)
                  .Take(n)
                  .SelectMany(p => p.Flights)
                  .OrderBy(f => f.FlightDate)
                  .ToList();

        }




        public void deletePlane()
        {
            //DateTime dateTime = DateTime.Now.AddYears(-10);
            //var oldPlanes = GetAll().Where(day => day.ManufactureDate < dateTime).ToList();
            //foreach (var plane in oldPlanes)
            //{
            //    Delete(plane);
            //}
               

            Delete(p=>p.ManufactureDate.Year <= DateTime.Now.AddYears(-10).Year);
            


        }
    }
}
