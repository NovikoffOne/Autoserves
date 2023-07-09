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
        public Detail(string name, string state="New")
        {
            Name = name;
            State = state;
        }

        public string Name { get; private set; }
        public string State { get; private set; }
    }
}
