using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passenger
    {
        public string Function { get; set; }

        [DataType(DataType.Currency)]
        public double Salary { get; set; }
        public DateTime EmployementDate { get; set; }

        public override string ToString()
        {
            return $"EmailAddress: {EmailAddress} - FirstName{FullName.FirstName} - LastName{FullName.LastName} - " +
                $"Function{Function} - Salary{Salary}";
        }

        public override void PassengerType()
        {
            base.PassengerType();
            Console.WriteLine("i'm staff member");
        }
    }
}
