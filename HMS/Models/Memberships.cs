using System;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Memberships
    {
        [Key]
        public int MembershipID { get; set; }
        public string MembershipType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
