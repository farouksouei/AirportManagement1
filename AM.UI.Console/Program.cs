// See https://aka.ms/new-console-template for more information
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Services;
using AM.Infrastructure;


Console.WriteLine("Hello, World!");

Plane plane1 = new Plane();
plane1.ManufactureDate = DateTime.Now;
plane1.Capacity = 20;
plane1.PlaneType = PlaneType.Boeing;

Console.WriteLine("Plane 1 : " + plane1);


Plane plane2 = new Plane(PlaneType.Airbus,22,DateTime.Now);

Console.WriteLine("Plane 2 : "+plane2);

Plane plane3 = new Plane
{
    ManufactureDate = DateTime.Now,
    Capacity = 23
};

Console.WriteLine("Plane 3 : " + plane3);
Console.WriteLine(" ");

//Passenger passenger1 = new Passenger { FirstName = "sarra", LastName = "bennour" };
//Console.WriteLine("passenger 1 :" + passenger1.CheckProfile("sarra", "bennour"));


//Passenger passenger2 = new Passenger { FirstName = "sarra", LastName = "bennour", EmailAddress="aa" };
//Console.WriteLine("passenger 2 :" + passenger2.CheckProfile2("sarra", "bennour","bb"));

//Passenger passenger3 = new Passenger { FirstName = "sarra", LastName = "bennour" };
//Console.WriteLine("passenger 3 :" + passenger2.CheckProfile3("sarra", "bennour"));

//Console.WriteLine(" ");

//passenger1.PassengerType();
//Console.WriteLine(" ");
//Staff staff = new Staff();
//staff.PassengerType();
//Console.WriteLine(" ");
//Traveller traveller = new Traveller();
//traveller.PassengerType();


//*********************************************************************************
//TP2
//FlightMethods fm = new FlightMethods();
//fm.Flights = TestData.listFlights;

//Console.WriteLine("liste des datesflights par destination");
//foreach( var  flight in fm.GetFlightDates("Paris") )
//    Console.WriteLine(flight);


//Console.WriteLine("\nliste des flights par filtre 1 et filtre 2");
//foreach (var flight in fm.GetFlights("Destination","Paris"))
//    Console.WriteLine(flight);

//fm.ShowFlightDetails(TestData.BoingPlane);

//Console.WriteLine("prgrammed flight: "+fm.ProgrammedFlightNumber(new DateTime(2022, 02, 01))+"\n");

//Console.WriteLine("Average Duration: " + fm.DurationAverage("Paris")+"\n");

//Console.WriteLine("Order Duration Flights: ");

//foreach(var f in fm.OrderedDurationFlights())
//{
//    Console.WriteLine(f);
//}

//Console.WriteLine("\nSenior Travellers: ");


//foreach (var f in fm.SeniorTravellers(TestData.flight1))
//{
//    Console.WriteLine(f.BirthDate);
//}

//Console.WriteLine("\nDestination Grouped Flights: ");
//fm.DestinationGroupedFlights();


//Console.WriteLine("\nDELEGATE flight: ");
//fm.FlightDetailsDel(TestData.BoingPlane);

//Console.WriteLine("\nDELEGATE duration: ");
//Console.Write(fm.DurationAverageDel("Paris"));



//Insertion dans la bdd
AMContext context = new AMContext();
context.Flights.Add(TestData.flight1);
context.SaveChanges();
Console.WriteLine("Flight inserted");

//Lecture de la bdd

Console.WriteLine(context.Flights.First().Plane.Capacity);


