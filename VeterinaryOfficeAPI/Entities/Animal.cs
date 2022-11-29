using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryOfficeAPI.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Species { get; set; }
        public string Breed { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal Weight { get; set; }
        public DateTime FirstVisit { get; set; }
        public DateTime LastVisit { get; set; }


    }
}
