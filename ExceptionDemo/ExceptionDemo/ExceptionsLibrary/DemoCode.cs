using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsLibrary
{
    public class DemoCode
    {
        public int GrandparentMethod(int position)
        {
            int output = 0;
            Console.WriteLine("Open Database Connection");
            try
            {
                output = ParentMethod(position);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("I caught the bad Argument", ex);
            }
            finally
            {
                Console.WriteLine("Close Database Connection");
            }
            return output;
        }

        public int ParentMethod(int position)
        {
            return GetNumber(position);
        }
        public int GetNumber(int position)
        {
            int output = 0;
            //try
            //{
                var numbers = new int[] { 1, 4, 7, 2 };
                output = numbers[position];
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //}

            return output;
        }
    }
}
