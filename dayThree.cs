using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode
{
    class dayThree
    {
        public static void dayThreeMethod()
        {
            String line;
            Char delmiter = ',';
            List<int> firstColumn = new List<int>();
            List<int> secondColumn = new List<int>();
            StreamReader reader = new StreamReader("dayThreeInput.txt");
            int total = 0;

            String[] buffer = null;
            List<String> numbers = new List<String>();

            line = reader.ReadLine();
            while (line != null)
            {
                buffer = line.Split(new String[] { "mul(" }, StringSplitOptions.None);
                foreach (String entry in buffer)
                {
                    if (entry.Contains(')') && entry.Contains(','))
                    {
                        numbers.Add(entry.Substring(0, entry.IndexOf(')')));
                    }
                }
                line = reader.ReadLine();
            }

            foreach (String str in numbers)
            {
                if (str.IndexOf(',') == 1 || str.IndexOf(',') == 2 || str.IndexOf(',') == 3)
                {
                    
                    buffer = str.Split(delmiter);
                    if (isDigitsOnly(buffer[0]) && isDigitsOnly(buffer[1]))
                    {
                        total = total + (Int32.Parse(buffer[0]) * Int32.Parse(buffer[1]));
                        
                    }
                }

            }
            Console.WriteLine(total);
        }

        public static Boolean isDigitsOnly(String str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}
