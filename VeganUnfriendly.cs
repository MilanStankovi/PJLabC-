using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_vezba
{
    internal class VeganUnfriendly : Exception
    {
        public VeganUnfriendly() { }

        public VeganUnfriendly(string message) : base(message) { }
    }
}
