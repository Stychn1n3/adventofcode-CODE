using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class dayFive
    {
        public static void dayFiveMethod()
        {
            String line;
            List<String> reportline = new List<String>();
            List<String> rules = new List<String>();
            String[] pages;
            String[] buffer;
            int middlePageTotal = 0;
            int middlePageTotal2 = 0;
            int middlePageTotal3 = 0;
            int page1;
            int page2;
            int errors = 1;
            try
            {
                Char delmiter = '|';
                Char delmiter2 = ',';
                StreamReader reader = new StreamReader("dayFiveInput.txt");
                Console.WriteLine("Start");
                line = reader.ReadLine();
                

                while (line != null)
                {
                    
                    if (line.Contains('|'))
                    {
                        rules.Add(line);
                    }
                    else
                    {
                        break;
                    }
                    line = reader.ReadLine();
                }
                Boolean alreadyCorrect;
                line = reader.ReadLine();
                while (line != null)
                {
                    alreadyCorrect = true;
                    pages = line.Split(delmiter2);
                    
                    while (errors > 0)
                    {
                        errors = rules.Count;
                        foreach (String s in rules)
                        {
                            buffer = s.Split(delmiter);
                            String rule1 = buffer[0];
                            String rule2 = buffer[1];
                            if (pages.Contains(rule1) && pages.Contains(rule2))
                            {
                                if (Array.IndexOf(pages, rule1) > Array.IndexOf(pages, rule2))
                                {
                                    pages[Array.IndexOf(pages, rule1)] = buffer[1];
                                    pages[Array.IndexOf(pages, rule2)] = buffer[0];
                                    errors--;
                                    alreadyCorrect = false;
                                }
                                else
                                {
                                    errors--;
                                }
                            }
                            else
                            {
                                errors--;
                            }
                        }


                            if (alreadyCorrect == true)
                            {
                            foreach (String b in pages)
                            {
                                Console.Write(b + ",");
                            }
                            Console.WriteLine("Already Correct");
                            }
                        else
                        {
                            foreach (String b in pages)
                            {
                                Console.Write(b + ",");
                            }
                            Console.WriteLine("Incorrect");
                        }


                            Console.WriteLine();
                        line = reader.ReadLine();
                    }

                    errors = 1;
                    if (alreadyCorrect == true)
                    {
                        middlePageTotal = middlePageTotal + Int32.Parse(pages[pages.Length / 2]);
                    }
                    if (alreadyCorrect == false)
                    {
                        middlePageTotal3 = middlePageTotal3 + Int32.Parse(pages[pages.Length / 2]);
                    }

                    middlePageTotal2 = middlePageTotal2 + Int32.Parse(pages[pages.Length / 2]);
                }
                Console.WriteLine("Already Correct Total: " + middlePageTotal);
                Console.WriteLine("Fixed Correct Total: " + middlePageTotal3);
                Console.WriteLine("Absolute Total: " + middlePageTotal2);
                reader.Close();
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
        public static int swap(int one, int two)
        {
            return Math.Abs(one - two);
        }
    }
}
