using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace adventofcode
{
    class dayThreeTwo
    {
        public static void dayThreePartTwoMethod()
        {
            String line;
            Char delmiter = ',';
            List<int> firstColumn = new List<int>();
            List<int> secondColumn = new List<int>();
            StreamReader reader = new StreamReader("dayThreeInput.txt");
            int total = 0;

            String[] buffer = null;
            List<String> numbers = new List<String>();

            Boolean active = true;

            line = reader.ReadLine();
            while (line != null)
            {
                List<int> donts = IndexOfAll(line, "don't()").ToList();
                List<int> dos = IndexOfAll(line, "do()").ToList();

                int count = 0;
                
                foreach (int test in donts)
                {
                    Console.WriteLine(line.Substring(dos[count]+4,donts[count]));
                    count++;
                }
                buffer = line.Split(new String[] { "mul(" }, StringSplitOptions.None);
                foreach (String entry in buffer)
                {

                    if (entry.Contains("do()"))
                    {
                        Console.WriteLine(entry + " -----" + active);
                        active = true;
                    }
                    else if (entry.Contains("don't()"))
                    {
                        Console.WriteLine(entry + " -----" + active);
                        active = false;
                    }
                    if (active == true)
                    {
                        if (entry.Contains(')') && entry.Contains(','))
                        {
                            numbers.Add(entry.Substring(0, entry.IndexOf(')')));
                        }
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
        public static String GetSubstringByString(String a, String b, String c)
        {
            if ((c.IndexOf(b) - c.IndexOf(a) - a.Length) > 0)
            {
                return c.Substring((c.IndexOf(a) + a.Length), (c.IndexOf(b) - c.IndexOf(a) - a.Length));
            }
            return null;
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

        public static IEnumerable<int> IndexOfAll(string sourceString, string subString)
        {
            return Regex.Matches(sourceString, subString).Cast<Match>().Select(m => m.Index);
        }

    }
}
