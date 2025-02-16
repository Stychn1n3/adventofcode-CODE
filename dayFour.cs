using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace adventofcode
{
    class dayFour
    {
        public static void dayFourMethod()
        {
            String line;
            Char delmiter = ',';
            List<int> firstColumn = new List<int>();
            List<int> secondColumn = new List<int>();
            StreamReader reader = new StreamReader("dayFourInput.txt");

            int rowCount = 0;
            int total = 0;
            List<String> letters = new List<String>();

            line = reader.ReadLine();
            while (line != null)
            {
                letters.Add(line);
                line = reader.ReadLine();
            }

            char[][] columns = new char[letters.Count][]; ;

            foreach (String str in letters)
            {
                columns[rowCount] = str.ToCharArray();
                rowCount++;
            }

            rowCount = 0;

            int position;
            foreach (char[] charArray in columns)
            {
                position = 0;
                foreach (char cha in charArray)
                {
                    
                    if (cha.Equals('X'))
                    {
                        if ((columns[rowCount].Length - position) > 3)
                        {
                            //Console.WriteLine((columns[rowCount][position].ToString() + columns[rowCount][position + 1] + columns[rowCount][position + 2] + columns[rowCount][position + 3]).ToString());
                            if ((columns[rowCount][position].ToString() + columns[rowCount][position + 1] + columns[rowCount][position + 2] + columns[rowCount][position + 3]).Contains("XMAS"))
                            {
                                Console.WriteLine("E");
                                total++;
                            }
                        }
                        if (position >= 3)
                        {
                            if ((columns[rowCount][position].ToString() + columns[rowCount][position - 1] + columns[rowCount][position - 2] + columns[rowCount][position - 3]).Contains("XMAS"))
                            {
                                Console.WriteLine("W");
                                total++;
                            }
                        }
                        if ((columns.Length - rowCount) > 3) 
                        {
                            if ((columns[rowCount][position].ToString() + columns[rowCount + 1][position] + columns[rowCount + 2][position] + columns[rowCount + 3][position]).Contains("XMAS"))
                            {
                                Console.WriteLine("S");
                                total++;
                            }
                        }
                        if (rowCount >= 3)
                        {
                            if ((columns[rowCount][position].ToString() + columns[rowCount - 1][position] + columns[rowCount - 2][position] + columns[rowCount - 3][position]).Contains("XMAS"))
                            {
                                Console.WriteLine("N");
                                total++;
                            }
                        }

                        if (rowCount >= 3 && position >= 3)
                        {
                            if ((columns[rowCount][position].ToString() + columns[rowCount - 1][position - 1] + columns[rowCount - 2][position - 2] + columns[rowCount - 3][position - 3]).Contains("XMAS"))
                            {
                                Console.WriteLine("N/W");
                                total++;
                            }
                        }
                        if ((columns.Length - rowCount) > 3 && (columns[rowCount].Length - position) > 3)
                        {
                            if ((columns[rowCount][position].ToString() + columns[rowCount + 1][position + 1] + columns[rowCount + 2][position + 2] + columns[rowCount + 3][position + 3]).Contains("XMAS"))
                            {
                                Console.WriteLine("S/E");
                                total++;
                            }
                        }
                        if (rowCount >= 3 && (columns[rowCount].Length - position) > 3)
                        {
                            if ((columns[rowCount][position].ToString() + columns[rowCount - 1][position + 1] + columns[rowCount - 2][position + 2] + columns[rowCount - 3][position + 3]).Contains("XMAS"))
                            {
                                Console.WriteLine("N/E");
                                total++;
                            }
                        }
                        if ((columns.Length - rowCount) > 3 && position >= 3)
                        {
                            if ((columns[rowCount][position].ToString() + columns[rowCount + 1][position - 1] + columns[rowCount + 2][position - 2] + columns[rowCount + 3][position - 3]).Contains("XMAS"))
                            {
                                Console.WriteLine("S/W");
                                total++;
                            }
                        }

                    }




                    position++;
                }
                rowCount++;
                
            }
            Console.Write(total);
        }
    }
}
