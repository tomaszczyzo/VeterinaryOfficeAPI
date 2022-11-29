using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryOfficeAPI.Entities
{
    public class Visit
    {
        public int Id { get; set; }
        public DateTime FirstVisit { get; set; }
        public DateTime LastVisit { get; set; }

        public int AnimalId { get; set; }
        public virtual Animal Animal { get; set; }
    }
}
