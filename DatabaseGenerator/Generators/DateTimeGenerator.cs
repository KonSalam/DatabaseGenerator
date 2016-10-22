using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    class DateTimeGenerator : BaseGenerator
    {
        DateTime tmpDateTimeStart;
        DateTime tmpDateTimeEnd;

        public DateTimeGenerator(string DateTimeStart) : base()
        {
           this.tmpDateTimeStart = Convert.ToDateTime(DateTimeStart);
        }
        public string GeneratePlanedDateTime()
        {

            tmpDateTimeEnd = tmpDateTimeStart.AddHours(Random.Next(2,5));
            return tmpDateTimeEnd.ToString();
        }
    }
}
