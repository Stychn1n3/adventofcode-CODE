using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class dayOne2
    {

        public static void dayOnePartTwoMethod()
        {
            String line;
            try
            {
                Char delmiter = '\t';
                List<int> firstColumn = new List<int>();
                List<int> secondColumn = new List<int>();
                StreamReader reader = new StreamReader("dayOneTwoInput.txt");
                Console.WriteLine("Start");
                line = reader.ReadLine();

                while (line != null)
                {
                    String[] buffer = line.Split(delmiter);
                    firstColumn.Add(Int32.Parse(buffer[0]));
                    secondColumn.Add(Int32.Parse(buffer[1]));
                    line = reader.ReadLine();
                }
                reader.Close();

                List<int> difference = new List<int>();

                int first = 0;
                int second = 0;
                //List<int> uniqueFirst = firstColumn.Distinct().ToList();
                foreach(int number in firstColumn)
                {
                    first = firstColumn.Count(x => x == number);
                    second = secondColumn.Count(x => x == number);
                    if (first > 0 && second > 0)
                    {
                        //Console.WriteLine(first + "  " + second + "   " + number + "   " + first * second);
                        difference.Add(number*second);
                    }

                }
                Console.WriteLine(difference.Sum());
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
    }
}
