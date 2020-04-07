using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Book;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grades.Test.Types
{
    [TestClass]
    public  class TypeTests
    {
        [TestMethod]
        public void UsingArray()
        {
            float[] grades;
            grades = new float[3];

            AddGrade(grades);

            Assert.AreEqual(89.9f, grades[1]);
        }

        private void AddGrade(float[] grades)
        {
            grades[1] = 89.9f;
        }

        [TestMethod]
        public void UpperCaseString()
        {
            string name = "scott";
            var upper = name.ToUpper();

            Assert.AreEqual("SCOTT", upper);
        }
        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            var dateTime = date.AddDays(1);
            Assert.AreEqual(2, dateTime.Day);
        }
        [TestMethod]
        public void ValueTypePassByValue()
        {
            int x = 46;

            IncrementNumber(ref x);

            Assert.AreEqual(47, x);
        }

        private void IncrementNumber(ref int number)
        {
            number  += 1;
        }
        [TestMethod]
        public void ReferenceTypesPassByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookName(ref book2);

            Assert.AreEqual("A new Book", book2.Name);
        }

        private void GiveBookName(ref GradeBook book)
        {
            book = book != null ? new GradeBook {Name = "A new Book"} : throw new ArgumentNullException(nameof(book));
        }

        [TestMethod]
        public void StringComparisons()
        {
            string nam1 = "Scott";
            string nam2 = "scott";

            bool result = String.Equals(nam1, nam2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void IntVariableHoldValues()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4; 
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradBookVariableHoldReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Scot's grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        }
    }
}
