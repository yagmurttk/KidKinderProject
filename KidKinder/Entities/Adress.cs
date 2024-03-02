using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KidKinder.Entities
{
    public class Adress
    {
        public int AdressId { get; set; }
        public string Description { get; set; }
        public string AdressDetail { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string OpeningHours { get; set; }
    }
}