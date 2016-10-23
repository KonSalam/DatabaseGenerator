using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseGenerator
{
    public class DateTimeGenerator : BaseGenerator
    {
        public DateTime DateTimePlanedStart { get; set; }
        public DateTime DateTimePlanedEnd { get; set; }
        public DateTime DateTimeRealStart { get; set; }
        public DateTime DateTimeRealEnd { get; set; }
        private int tmpRandomStartDelyMinutes;

        public DateTimeGenerator(string DateTimeStart) : base()
        {
            this.DateTimePlanedStart = Convert.ToDateTime(DateTimeStart);
        }
        public void GeneratePlanedDateTimeEnd()
        {
            DateTimePlanedEnd = DateTimePlanedStart.AddHours(Random.Next(2, 5));
            DateTimePlanedStart = DateTimePlanedEnd;
        }

        public void GenerateRealDateTimeStart()
        {
            if (GenerateStatusTime() == 0)
            {
                DateTimeRealStart = DateTimePlanedStart;
                tmpRandomStartDelyMinutes = 0;
            }
            else
            {
                tmpRandomStartDelyMinutes = Random.Next(0, 30);
                DateTimeRealStart = DateTimePlanedStart.AddMinutes(tmpRandomStartDelyMinutes);
            }
        }

        public void GenerateRealDateTimeEnd()
        {
            if (GenerateStatusTime() == 0)
            {
                DateTimeRealEnd = DateTimePlanedEnd;
            }
            else
            {
                int tmpRandomEndDelyMinutes = Random.Next(0, 40);
                DateTimeRealEnd = DateTimePlanedEnd.AddMinutes(tmpRandomStartDelyMinutes + tmpRandomEndDelyMinutes);
            }
        }

        public int GenerateStatusTime()
        {
            return Random.Next(0, 2);
        }
    }
}