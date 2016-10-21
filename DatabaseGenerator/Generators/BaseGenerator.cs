using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    public abstract class BaseGenerator
    {
        public static Random Random { get; private set; }

        static BaseGenerator()
        {
            Random = new Random();
        }
    }
}
