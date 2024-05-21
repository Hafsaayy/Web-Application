using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Models
{
    public class TrainingSessions
    {
        [Key]
        public int SessionID { get; set; }

        [Required]
        public String SessionName { get; set; }

        [Required]
        public String SessionDescription { get; set; }


    }
}
