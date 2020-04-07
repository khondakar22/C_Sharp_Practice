using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddBook(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty ");
                }
                if (_name != value)
                {
                    NameChangeEventArgs args = new NameChangeEventArgs { ExistingName = _name, NewName = value };
                    NameChanged?.Invoke(this, args);
                }
                _name = value;
            }
        }

        //public NameChangedDelegate NameChanged;
        public event NameChangedDelegate NameChanged;

        protected string _name;
    }
}
