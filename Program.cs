using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {

            IBook book = new DiskBook("Catologul lui Alex");
            book.GradeAdded += OnGradeAdded;

            //  book.AddGrade(89.1);
            //  book.AddGrade(90.5);
            //  book.AddGrade(77.5);

            EnterGrades(book);

            var stats = book.GetStatistics();

            
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");

        }

        private static void EnterGrades(IBook book)
        {
            
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' tp quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }


            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }

    }
}
