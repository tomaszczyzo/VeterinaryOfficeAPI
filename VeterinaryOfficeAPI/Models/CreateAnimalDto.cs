using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryOfficeAPI.Models
{
    public class CreateAnimalDto
    {
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Weight { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime FirstVisit { get; set; }
        public DateTime LastVisit { get; set; }
    }
}
