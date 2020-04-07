using System;
using System.IO;

namespace SchedulerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RunSchedule();
        }

        public static void RunSchedule()
        {
            string path = Path.GetFullPath("C:\\workspace\\SchedulerTest") + "\\" +
                          DateTime.Now.ToString("MM/dd/yyyy") + "_Log.txt";
            try
            {
                // Put your own logic which you want to perform on schedule basis
                if (!File.Exists(path))
                {
                    File.Create(path);
                }
            }
            catch (Exception e)
            {
                // Log error and send a email to admin that schedule is failed... 
                string errorLogPath = @"D:\MyTest.txt";
                File.AppendAllText(errorLogPath, Environment.NewLine + e.Message);
            }
        }
    }
}
