using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Singleton
{
    class UserOnly
    {
        public Program Program { get; set; }
        public void Launch(string Name)
        {
            Program = Program.getInstance(Name);
        }
    }
}
