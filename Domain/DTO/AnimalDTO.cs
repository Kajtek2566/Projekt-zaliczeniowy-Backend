using Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Species { get; set; }
    }
}
