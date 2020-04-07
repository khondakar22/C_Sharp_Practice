using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    //public delegate void NameChangedDelegate(string existingName, string newName);
    public delegate void NameChangedDelegate(object sender, NameChangeEventArgs args);
}
