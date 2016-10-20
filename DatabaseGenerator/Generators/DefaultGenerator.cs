using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    public class DefaultGenerator : BaseGenerator
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public DefaultGenerator() : base()
        {
            Min = 0;
        }

        public override string Generate(string[] list)
        {
            Max = list.Length;
            return list[Random.Next(Min, Max)];
        }
    }
}