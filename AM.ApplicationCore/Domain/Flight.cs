using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AM.ApplicationCore.Domain
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Destination { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public float EstimatedDuration { get; set; }
        public DateTime FlightDate { get; set; }

        public int FlightId { get; set; }
        public string AirlineLogo { get; set; }
        
        [ForeignKey("PlaneFk")]
        public int PlaneFk { get; set; }
        public virtual Plane Plane { get; set; }
        //public ICollection<Passenger> Passengers { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }



        public override string ToString()
        {
            return $"Departure: {Departure} - Destination: {Destination} - EffectiveArrival: {EffectiveArrival} - " +
                $"EstimatedDuration: {EstimatedDuration}";
        }
    }
}