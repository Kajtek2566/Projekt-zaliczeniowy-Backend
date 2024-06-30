using Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Species { get; set; }

        public Status Status { get; set; }

        public ICollection<AnimalSponsor>? AnimalSponsors { get; set; }
    }
}
