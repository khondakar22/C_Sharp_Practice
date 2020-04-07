using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.String;

namespace Book
{
    public class GradeBook : GradeTracker 
    {
        public GradeBook ( )
        {
            _name = "Empty";
            grades = new List<float> ( );
        }

        public override  GradeStatistics ComputeStatistics ( )
        {
            GradeStatistics stats = new GradeStatistics ( );



            float sum = 0;
            foreach (var grade in grades)
            {
                stats.HighestGrade = Math.Max ( grade, stats.HighestGrade );
                stats.LowestGrade = Math.Min ( grade, stats.LowestGrade );
                sum += grade;

            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }
        public override void AddBook ( float grade )
        {
            grades.Add ( grade );
        }


        public override void WriteGrades ( TextWriter destination )
        {
            for (int i = 0; i < grades.Count; i++)
            {
                destination.WriteLine ( grades[i] );
            }
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        protected List<float> grades;
      
    }
}
