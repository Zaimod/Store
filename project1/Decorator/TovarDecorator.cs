using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Decorator
{
    abstract class TovarDecorator : Tovar
    {
        protected Tovar tovar;
        protected TovarDecorator(Tovar tovar) : base()
        {
            this.tovar = tovar;
        }
    }
}
