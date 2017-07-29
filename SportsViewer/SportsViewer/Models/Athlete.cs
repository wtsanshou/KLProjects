using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsViewer.Models
{
    class Athlete
    {
        public string avatar_url { get; set; }

        public string country { get; set; }

        public string last_played { get; set; }

        public string name { get; set; }

        public string position { get; set; }

        public bool is_injured { get; set; }

        public int id { get; set; }
    }
}
