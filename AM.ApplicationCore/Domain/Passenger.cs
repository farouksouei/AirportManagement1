using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger
    {
        
        public int Id { get; set; }

        [Display(Name ="Date of birth")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [DataType(DataType.EmailAddress)]
        //[EmailAddress]
        public string EmailAddress { get; set; }

        public virtual FullName FullName { get; set; }

        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }

        [RegularExpression(@"^[0-9]{8}$")]  // tjrs @"^*********$"et on peut pas utiliser dataType.phoneNumber car c'est string on sait pas le format phoneNumber
        public string TelNumber { get; set; }
        //public ICollection<Flight> Flights { get; set; }

        public virtual ICollection<Tickets> Tickets { get; set; }


        public override string ToString()
        {
            return $"BirthDate {BirthDate} - EmailAddress: {EmailAddress} - FirstName{FullName.FirstName} - " +
                $"LastName{FullName.LastName}";
        }

        public bool CheckProfile(string firstname, string lastname)
        {
            return FullName.FirstName == firstname && FullName.LastName == lastname;
        }

        public bool CheckProfile2(string firstname, string lastname, string email)
        {
            if (email == null)
                return FullName.FirstName == firstname && FullName.LastName == lastname;
            else
                return FullName.FirstName == firstname && FullName.LastName == lastname && EmailAddress == email;
        }

        public bool CheckProfile3(string firstname, string lastname, string email=null)
        {
            if (email != null)
                return FullName.FirstName == firstname && FullName.LastName == lastname && EmailAddress == email;
            else
                return FullName.FirstName == firstname && FullName.LastName == lastname;
        }

        public virtual void PassengerType()
        {
            Console.WriteLine("i'm passenger");
        }
    }
}
