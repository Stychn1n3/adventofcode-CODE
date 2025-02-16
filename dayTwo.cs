using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class dayTwo
    {
        public static void dayTwoMethod()
        {
            String line;
            List<String> reportline = new List<String>();
            try
            {
                Char delmiter = ' ';
                List<int> firstColumn = new List<int>();
                List<int> secondColumn = new List<int>();
                StreamReader reader = new StreamReader("dayTwoInput.txt");
                Console.WriteLine("Start");
                line = reader.ReadLine();

                while (line != null)
                {
                    //String[] buffer = line.Split(delmiter);
                    reportline.Add(line);
                    line = reader.ReadLine();
                    
                }
                reader.Close();

                String[] buffer = null;
                String[] buffer2 = null;
                int[] sortedlist = null;
                int[] sortedlist2 = null;
                String[] originalLine = null;
                int safeCounter = 0;

                Boolean safe = true;
                foreach (String str in reportline)
                {
                    safe = true;
                    if (str != null)
                    {
                        buffer = str.Split(delmiter);
                        buffer2 = str.Split(delmiter);

                        sortedlist = Array.ConvertAll(buffer, s => int.Parse(s));
                        sortedlist2 = Array.ConvertAll(buffer2, s => int.Parse(s));

                        Array.Sort(sortedlist);
                        Array.Sort(sortedlist2);
                        Array.Reverse(sortedlist);

                        originalLine = str.Split(delmiter);

                        for (int i = 0; i < originalLine.Length; i++)
                        {
                            //Console.WriteLine(buffer[0] + "" + buffer2[0]);
                            if (!originalLine[i].Equals(sortedlist[i].ToString()) && !originalLine[i].Equals(sortedlist2[i].ToString()))
                            {
                                Console.WriteLine("unsafe:" + str + " unsorted");
                                safe = false;
                                break;
                            }
                        }
                        if (safe == true)
                        {
                            for (int i = 0; i < originalLine.Length-1; i++)
                            {
                                if (Math.Abs(sortedlist[i] - sortedlist[i+1]) > 3)
                                {
                                    Console.WriteLine("unsafe:" + str + " steep");
                                    safe = false;
                                }
                                if (sortedlist[i] == sortedlist[i + 1])
                                {
                                    Console.WriteLine("unsafe:" + str + " little");
                                    safe = false;
                                }
                            }
                            
                        }
                        if (safe == true)
                        {
                            Console.WriteLine("safe:" + str);
                            safeCounter++;
                        }
                        Console.WriteLine(safeCounter);
                    }

                }

                List<int> difference = new List<int>();

                int first = 0;
                int second = 0;
                //List<int> uniqueFirst = firstColumn.Distinct().ToList();
                foreach (int number in firstColumn)
                {
                    first = firstColumn.Count(x => x == number);
                    second = secondColumn.Count(x => x == number);
                    if (first > 0 && second > 0)
                    {
                        //Console.WriteLine(first + "  " + second + "   " + number + "   " + first * second);
                        difference.Add(number * second);
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

        public static int findDifference(int one, int two)
        {
            return Math.Abs(one - two);
        }
    }
}
