using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class AnimalSponsor
    {
        public int Id { get; set; }
        public string PriceOfFunding { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartOfSponsoring { get; set;}

        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }

        public string UserName { get; set; }

        public ZooUser? ZooUser { get; set; }


    }
}
