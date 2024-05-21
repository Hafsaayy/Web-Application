using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Models
{
    public class Classes
    {
        [Key]
        public int ClassID { get; set; }

        [Required]
        public String ClassName { get; set; }

        [Required]
        public String ClassDescription { get; set; }
    }
}
