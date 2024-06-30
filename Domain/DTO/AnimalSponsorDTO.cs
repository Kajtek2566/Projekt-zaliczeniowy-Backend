using Domain.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AnimalSponsorDTO
    {
        public int Id { get; set; }
        public string PriceOfFunding { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartOfSponsoring { get; set; }

        public int AnimalId { get; set; }

        public string UserName { get; set; }
    }
}
