﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeAndTravel
{
    public class Merchant : Shopkeeper, ITraveller
    {
        public Merchant(string name, Location location) 
            : base(name, location)
        {
        }
        
        public virtual void TravelTo(Location location)
        {
            this.Location = location;
        }
    }
}
