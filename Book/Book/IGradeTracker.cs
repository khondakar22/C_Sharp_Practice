using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    internal interface IGradeTracker : IEnumerable
    {
        void AddBook(float grade);
        GradeStatistics ComputeStatistics();
        void WriteGrades(TextWriter destination);

        string Name { get; set; }
    }
}
