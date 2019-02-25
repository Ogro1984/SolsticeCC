using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapi
{
    public class Items
    {
        public string Name { get; internal set; }
        public double Weight { get; internal set; }

        [Serializable]
        public class Item

        {
            public string Name;
            public double Weight;
        }


    }
}
