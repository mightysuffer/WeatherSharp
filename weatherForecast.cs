using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace coursa42
{
    public class weatherForecast
    {
        public city city { get; set; }
        public List<list> list { get; set; }
        public string message { get; set; }
        
    }
    public class temp
    {
        public double day { get; set; }

        public double eve { get; set; }

        public double morn { get; set; }

    }

    public class weather
    {
        public string main { get; set; }

        public string description { get; set; }

        public string icon { get; set; }
              
    }
    public class city 
    {
        public string name { get; set; }

    }

    public class list
    {
        public double dt { get; set; } //ms day

        public double pressure { get; set; }

        public double humidity { get; set; }

        public double speed { get; set; }

        public temp temp { get; set; }

        public List<weather> weather { get; set; }
    }
}
