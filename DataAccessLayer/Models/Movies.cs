using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public DateTime ReleaseDate { get; set; }

        public ICollection<MultiMovie> ListMultiplex { get; set; } = new HashSet<MultiMovie>();


    }
}
