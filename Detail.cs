using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Autoserves
{
    class Detail
    {
        public string Name { get; private set; }
        //public int Price { get; private set; }
        public string State { get; private set; }

        public Detail(string name, string state="New")
        {
            Name = name;
            //Price = price;
            State = state;
        }
    }
}
