﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Interfaces
{
    public interface IServicePlane : IService<Plane>
    {

        public IList<Passenger> GetPassengersByPlane(Plane plane);

        public IList<Flight> GetFlights(int n);



        public void deletePlane();








    }
}
