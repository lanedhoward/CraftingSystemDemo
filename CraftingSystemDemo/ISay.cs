using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CraftingSystemDemo
{
    interface ISay
    {
        void Say(string line);
        void Say(string line, bool waitAfter);
    }
}
