using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Gym.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gym.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Members> Members { get; set; }
        public DbSet<Memberships> Memberships { get; set; }
        public DbSet<TrainingSessions> TrainingSessions { get; set; }
        public DbSet<Staff> Staffs { get; set; }

    }
}
