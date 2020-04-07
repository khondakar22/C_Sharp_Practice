using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Test
{
	[TestClass]
    public class GradeBookTests
    {
        [TestMethod]
        public void ComputesHighestGrade()
        {
			GradeBook book = new GradeBook();
			book.AddBook(10);
			book.AddBook(90);

            GradeStatistics result = book.ComputeStatistics();
			Assert.AreEqual(90, result.HighestGrade);
        }

        [TestMethod]
        public void ComputesLowestGrade()
        {
            GradeBook book = new GradeBook();
            book.AddBook(10);
            book.AddBook(90);

            GradeStatistics result = book.ComputeStatistics();
            Assert.AreEqual(10, result.LowestGrade);
        }
    }

}
