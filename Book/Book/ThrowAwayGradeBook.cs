using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public class ThrowAwayGradeBook : GradeBook

    {


        public override GradeStatistics ComputeStatistics()
        {
            float lowest = float.MaxValue;

            foreach (float grade in grades)
            {
                lowest = Math.Min(grade, lowest);
            }

            return base.ComputeStatistics();
        }
    }
}
