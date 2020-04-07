using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Book
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpeakMethod();
            IGradeTracker book = CreateGradeBook();
            //book.NameChanged += OnNameChanged;
            //book.Name = "Riyadh's Grade Book";
            //book.Name = "Komol's Grade Book";
            GetBookName(book);
            AddGrades(book);
            SaveGrades(book);
            //book.WriteGrades(Console.Out);
            WriteResults(book);
        }

       

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void SpeakMethod()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the grade book program");
        }

        private static void WriteResults(IGradeTracker book)
        {
            GradeStatistics stats = book.ComputeStatistics();
            Console.WriteLine(book.Name);

            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }

            WriteResult("Average", stats.AverageGrade);
            //WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void SaveGrades(IGradeTracker book)
        {
            using (StreamWriter outPutFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outPutFile);
                outPutFile.Close();
            }
        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddBook(91);
            book.AddBook(7.2f);
            book.AddBook(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            try
            {
                Console.WriteLine("Enter a name");
                book.Name = Console.ReadLine();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Something wend wrong!");
            }
        }

        //static void OnNameChanged(string existingName, string newName)
        //{
        //    Console.WriteLine($"Grade book changing name from {existingName} to {newName}");
        //}

        //static void OnNameChanged(object sender, NameChangeEventArgs args)
        //{
        //    Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        //}



        //static void WriteResult(string description, int result)
        //{
        //    Console.WriteLine(description + ": " + result);
        //}

        static void WriteResult(string description, float result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }
        static void WriteResult(string description, string result)
        {
            Console.WriteLine("{0}: {1}", description, result);
        }
    }
    
}
