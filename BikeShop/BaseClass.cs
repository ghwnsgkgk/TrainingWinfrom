using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeShop
{
    public class BaseClass
    {
        public int money { get; set; }
        public int car { get; set; }
        public void Spend() 
        {
            Debug.WriteLine("DO something");
                
         }
    }
}
