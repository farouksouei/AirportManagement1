using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services
{
    public class FlightMethods
    {
        public List<Flight> Flights { get; set; } = new List<Flight> {}; //car l'initialisation d'objet ce fait avec {}


        //delegate
        public Action<Plane> FlightDetailsDel;
        public Func<string,double> DurationAverageDel;

        public FlightMethods() 
        {
            FlightDetailsDel = plane =>
            {

                var flightDetails = Flights
                    .Where(f => f.Plane == plane)
                    .Select(f => (f.FlightDate, f.Destination));

                foreach (var detail in flightDetails)
                {
                    Console.WriteLine($"Destination: {detail.Destination}, Date: {detail.FlightDate}");
                }
            };
            //FlightDetailsDel = ShowFlightDetails;
            //DurationAverageDel = DurationAverage;
            DurationAverageDel = destination =>
            {
                return Flights.Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration).Average();
            };
        }


        public List<DateTime> GetFlightDates(string destination)
        {
            List<DateTime> flightDates = new List<DateTime>();
            //for (int i = 0; i < Flights.Count; i++)
            //{
            //    if (Flights[i].Destination == destination)
            //        flightDates.Add(Flights[i].FlightDate);
            //}
            foreach (Flight flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    flightDates.Add(flight.FlightDate);
                }
            }
            return flightDates;
        }

        public List<Flight> GetFlights(string filterType, string filterValue)
        {
            List<Flight> flights = new List<Flight> { };

            foreach (Flight flight in Flights)
            {
                switch (filterType)
                {
                    case "Destination":
                        if (flight.Destination == filterValue)
                        {
                            flights.Add(flight);
                        }
                        break;

                    case "Departure":
                        if (flight.Departure == filterValue)
                        {
                            flights.Add(flight);
                        }
                        break;
                    case "EffectiveArrival":
                        if (flight.EffectiveArrival.ToString() == filterValue)
                        {
                            flights.Add(flight);
                        }
                        break;
                    case "EstimatedDuration":
                        if (flight.EstimatedDuration.ToString() == filterValue)
                        {
                            flights.Add(flight);
                        }
                        break;
                    case "FlightDate":
                        if (flight.FlightDate.ToString() == filterValue)
                        {
                            flights.Add(flight);
                        }
                        break;
                }
            }
            return flights;
        }

        public List<DateTime> FlightDates (string destination)
        {
            var flightDates = Flights.Where(flight =>  flight.Destination.Equals(destination))
                .Select(flight => flight.FlightDate)
                .ToList();
            return flightDates;
                
            //return Flights.Where(flight => flight.Destination == Destination)
            //    .Select(flight => flight.FlightDate)
            //    .ToList();
        }

        public void  ShowFlightDetails(Plane plane)
        {
            var flightDetails = Flights
                .Where(f => f.Plane == plane)
                .Select(f => (f.FlightDate, f.Destination));

            foreach (var detail in flightDetails)
            {
                Console.WriteLine($"Destination: {detail.Destination}, Date: {detail.FlightDate}");
            }
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            var querry = from f in Flights
                         where f.FlightDate == startDate.AddDays(7)
                         select f;

            return querry.Count();
        }

        public double DurationAverage(string destination)
        {
            return Flights.Where(f => f.Destination == destination)
                .Select(f => f.EstimatedDuration).Average();
        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            var querry = Flights.OrderBy(f => f.EstimatedDuration);
            return querry.ToList();
            
        }

        //public IEnumerable<Passenger> SeniorTravellers(Flight flight)
        //{
        //    return flight.Passengers.OfType<Traveller>()
        //           .OrderBy(p => p.BirthDate).Take(3);
        //}

        public IEnumerable<IGrouping<string,Flight>> DestinationGroupedFlights()
        {
            var req = Flights.GroupBy(f => f.Destination);
            foreach (var f in req)
            {
                Console.WriteLine("Destination "+f.Key);
                foreach (var d in f)
                   Console.WriteLine("Decollage " + d.FlightDate);
            }
            return req;
        }

    }
}
