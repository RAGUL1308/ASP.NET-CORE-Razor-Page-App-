using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPageMovies.Models;

namespace RazorPageMovies.Data
{
    public class RazorPageMoviesContext : DbContext
    {
        public RazorPageMoviesContext (DbContextOptions<RazorPageMoviesContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPageMovies.Models.Movie> Movie { get; set; } = default!;
    }
}
