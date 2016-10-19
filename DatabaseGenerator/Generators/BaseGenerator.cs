using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator.Generators
{
    public abstract class BaseGenerator
    {
        public static Random Random { get; private set; }

        static BaseGenerator()
        {
            Random = new Random();
        }

        //public abstract object Generate(GeneratorContext generatorContext);
    }
}
