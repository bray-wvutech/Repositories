using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Assignment3.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace Assignment3.Data
{
    public class Assignment3Context : IdentityDbContext
    {
        public Assignment3Context (DbContextOptions<Assignment3Context> options)
            : base(options)
        {
        }

        public DbSet<Assignment3.Models.Movie> Movie { get; set; } = default!;
    }
}
