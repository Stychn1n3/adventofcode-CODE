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
    class dayOne
    {

        public static void dayOneMethod()
        {
            String line;
            try
            {
                Char delmiter = '\t';
                List<int> firstColumn = new List<int>();
                List<int> secondColumn = new List<int>();
                StreamReader reader = new StreamReader("dayOneInput.txt");
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
                

                firstColumn.Sort();
                secondColumn.Sort();

                List<int> difference = new List<int>();

                for (int i = 0; i < firstColumn.Count; i++ )
                {
                    difference.Add(findDifference(firstColumn[i],secondColumn[i]));
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

        public static int findDifference(int one, int two)
        {
            return Math.Abs(one - two);
        }
    }
}
