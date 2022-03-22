using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Screens
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MultiplexId { get; set; }
        public Multiplex Multiplex { get; set; }
    }
}
