using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public enum PlaneType { Boeing , Airbus }
    public class Plane
    {
        [Range(0, int.MaxValue)]
        public int Capacity { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int PlaneId { get; set; }
        public virtual PlaneType PlaneType { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }

        public override string ToString()
        {
            return $"PlaneType {PlaneType} - Capacity: {Capacity} - ManufactureDate{ManufactureDate}";
        }

        public Plane() { }

        public Plane(PlaneType pt, int capacity, DateTime date)
        {
            PlaneType = pt;
            Capacity = capacity;
            ManufactureDate = date;
         }
    }
}
