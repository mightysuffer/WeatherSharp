using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coursa42
{
    class weaterInfo
    {
        public class coord
        {
            public double lon { get; set; }
            
            public double lat { get; set; }
        } //end coord

        public class weather
        {
            public int id { get; set; }
            public string main { get; set; }
            public string description { get; set; }

            public string icon;
          
        } //end weather

        public class main
        {
            public double temp { get; set; }
            public double pressure { get; set; }
            public double humidity { get; set; }
            
        }//end main

        public class wind
        {
            public double speed { get; set; }
            
        } //end 
        public class sys
        {
            public string country { get; set; }
            
        } // sys end 

        public class root
        {
            public string name { get; set; }
            public sys sys { get; set; }
            public double dt { get; set; }
            public wind wind { get; set; }
            public main main { get; set; }
            public weather[] weather { get; set; }
            public coord coord { get; set; }
            public string message { get; set; }
        }
    }
}
