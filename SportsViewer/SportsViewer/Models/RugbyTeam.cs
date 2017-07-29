using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsViewer.Models
{
    class Team
    {
        public List<Athlete> athletes { get; set; }

        public List<Squad> squads { get; set; }
    }
}
