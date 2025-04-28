using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class FullName
    {
        [MinLength(3, ErrorMessage = "la longueur doit etre minimum 3")]
        [MaxLength(25, ErrorMessage = "la longueur doit etre maximum 25")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
