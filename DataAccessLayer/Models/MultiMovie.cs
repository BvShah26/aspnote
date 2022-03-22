using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class MultiMovie
    {
        public int Id { get; set; }
        public string MultiplexId { get; set; }
        public string MovieId { get; set; }


        public Multiplex Multiplex { get; set; }
        public Movies Movie { get; set; }
    }
}
