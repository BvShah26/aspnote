using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Multiplex
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Mobile { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public ICollection<Screens> Screens { get; set; } = new HashSet<Screens>();
        public ICollection<MultiMovie> ListMovies { get; set; } = new HashSet<MultiMovie>();
    }
}
