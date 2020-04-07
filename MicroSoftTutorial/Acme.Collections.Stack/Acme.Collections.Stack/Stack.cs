using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acme.Collections.Stack
{
    internal class Stack
    {
        private Entry _top; 
        public void Push(object data)
        {
            _top = new Entry(_top , data);
        }

        public object Pop()
        {
            if (_top == null)
            {
                throw new InvalidOperationException();

            }

            var result = _top.Data;
            _top = _top.Next;
            return result;
        }

        private class Entry
        {
            public readonly Entry Next;
            public readonly object Data;

            public Entry(Entry next, object data)
            {
                this.Next = next;
                this.Data = data; 
            }
        }


      
    }
}
