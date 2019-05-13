using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project1.Singleton
{
    class Program
    {
        public static Program instance;
        public string Name { get; private set; }
        protected Program(string Name)
        {
            this.Name = Name;
        }
        public static Program getInstance(string Name)
        {
            if (instance == null)
                instance = new Program(Name);
            return instance;
        }
    }
}
