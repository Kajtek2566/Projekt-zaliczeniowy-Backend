using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum Status
    {
        [Display(Name = "Sponsored")]
        Sponsored,
        [Display(Name = "Unsponsored")]
        Unsponsored,
    }
}
