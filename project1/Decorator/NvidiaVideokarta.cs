using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using project1.Data.Context;
using project1.Data;

namespace project1.Decorator
{
    class NvidiaVideokarta : TovarDecorator
    {
        public NvidiaVideokarta(Tovar tovar) : base(tovar)
        {

        }

        public override int GetCost(string n)
        {
            int temp = 0;
            using (Model1 db = new Model1())
            {
                var v = db.products.Where(t => t.title == n);
                foreach (var i in v)
                {
                    temp = (int)i.price;
                }
            }
            return temp;
        }
    }
}
