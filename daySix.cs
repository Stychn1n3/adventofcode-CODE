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
    class daySix
    {
        public static void daySixMethod()
        {
            String line;
            Char delmiter = ',';
            List<int> firstColumn = new List<int>();
            List<int> secondColumn = new List<int>();
            int startingRow = 0;
            int startingColumn = 0;
            StreamReader reader = new StreamReader("daySixInput.txt");

            int rowCount = 0;
            int total = 0;
            List<String> tiles = new List<String>();

            line = reader.ReadLine();
            while (line != null)
            {
                tiles.Add(line);
                line = reader.ReadLine();
            }

            char[][] columns = new char[tiles.Count][]; ;

            foreach (String str in tiles)
            {
                columns[rowCount] = str.ToCharArray();
                if (str.Contains('^'))
                {
                    startingRow = rowCount;
                    startingColumn = str.IndexOf('^');
                    Console.WriteLine("Starting row: " + startingRow);
                    Console.WriteLine("Starting postition: " + startingColumn);
                }
                rowCount++;
            }
            int xModifier = 0;
            int yModifier = -1;

            char nextMovement = '.';
            columns[startingRow][startingColumn] = 'X';
            while (startingRow + yModifier < columns.Length && startingColumn + xModifier < rowCount && startingRow + yModifier > -1 && startingColumn + xModifier > -1)
            {
                //Console.WriteLine("running: " + total);
                nextMovement = columns[startingRow + yModifier][startingColumn + xModifier];
                if (nextMovement.ToString().Equals(".") || nextMovement.ToString().Equals("X"))
                {
                    columns[startingRow + yModifier][startingColumn + xModifier] = 'X';
                    if (xModifier == 0 && yModifier == -1)
                    {
                        //right
                        startingRow--;
                    }
                    else if (xModifier == 1 && yModifier == 0)
                    {
                        //right
                        startingColumn++;
                    }
                    else if (xModifier == 0 && yModifier == 1)
                    {
                        //right
                        startingRow++;
                    }
                    else if (xModifier == -1 && yModifier == 0)
                    {
                        //right
                        startingColumn--;
                    }
                }
                if (nextMovement.ToString().Equals("#"))
                {
                    if (xModifier == 0 && yModifier == -1)
                    {
                        //right
                        xModifier = 1;
                        yModifier = 0;
                    }
                    else if (xModifier == 1 && yModifier == 0)
                    {
                        //right
                        xModifier = 0;
                        yModifier = +1;
                    }
                    else if (xModifier == 0 && yModifier == 1)
                    {
                        //right
                        xModifier = -1;
                        yModifier = 0;
                    }
                    else if (xModifier == -1 && yModifier == 0)
                    {
                        //right
                        xModifier = 0;
                        yModifier = -1;
                    }
                    

                }
                //Thread.Sleep(10);
                //foreach (char[] charArray in columns)
                //{
                //    foreach (char cha in charArray)
                //    {
                //        Console.Write(cha);
                        
                //    }

                //    Console.WriteLine("");
                //}
                //Console.WriteLine("--------------------");

            }
            foreach (char[] charArray in columns)
            {
                foreach (char cha in charArray)
                {
                    if (cha.Equals('X'))
                    {
                        total++;
                    }
                }
            }
            foreach (char[] charArray in columns)
            {
                foreach (char cha in charArray)
                {
                    Console.Write(cha);
                    
                }
                Console.WriteLine("");

            }
            Console.WriteLine("--------------------");
            Console.WriteLine(total);
        }
    }
}
