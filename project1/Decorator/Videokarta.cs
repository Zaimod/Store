using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Decorator
{
    class Videokarta : Tovar
    {
        public Videokarta() : base()
        {
        }

        public override int GetCost(string n)
        {
            return 0;
        }
    }
}
