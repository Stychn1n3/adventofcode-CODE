using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class dayTwoTwo
    {
        public static void dayTwoPartTwoMethod()
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

                int[] sortedlist = null;
                int[] sortedlist2 = null;
                
                int safeCounter = 0;
                double errorCounter = 0;

                Boolean safe = true;
                foreach (String str in reportline)
                {
                    safe = true;
                    errorCounter = 0;
                    if (str != null)
                    {

                        List<int> originalLine = new List<int>(Array.ConvertAll(str.Split(delmiter), s => int.Parse(s)));
                        List<int> originalLine2 = new List<int>(Array.ConvertAll(str.Split(delmiter), s => int.Parse(s)));
                        sortedlist = Array.ConvertAll(str.Split(delmiter), s => int.Parse(s));
                        sortedlist2 = Array.ConvertAll(str.Split(delmiter), s => int.Parse(s));

                        Array.Sort(sortedlist);
                        Array.Sort(sortedlist2);
                        Array.Reverse(sortedlist);

                        
                        int loop = originalLine.Count-1;
                        for (int i = 0; i < loop; i++)
                        {
                            if (originalLine[i] != sortedlist[i] && originalLine[i] != sortedlist2[i])
                            {
                                //    Console.WriteLine("unsafe:" + str + " unsorted");
                                    originalLine.Remove(originalLine[i]);
                                loop--;
                                i = -1;
                                //foreach (int asd in originalLine)
                                //{
                                //    Console.Write(asd + " ");
                                //}
                                //Console.WriteLine();
                                errorCounter++;
                                safe = false;
                                sortedlist = originalLine.ToArray();
                                sortedlist2 = originalLine.ToArray();
                                Array.Sort(sortedlist);
                                Array.Sort(sortedlist2);
                                Array.Reverse(sortedlist);

                            }
                        }
                         
                        loop = originalLine.Count - 1;
                        for (int i = 0; i < originalLine.Count-1; i++)
                            {
                            int one = originalLine[i];
                            int two = originalLine[i+1];
                            if (Math.Abs(one - two) > 3)
                                {
                                if (i == (originalLine.Count-2) || i == 0)
                                {
                                    //Console.WriteLine("unsafe:" + str + " steep ------------- " + originalLine.Count);
                                    originalLine.Remove(one);
                                    foreach (int asd in originalLine)
                                    {
                                       // Console.Write(asd + " ");
                                    }
                                    errorCounter++;
                                    safe = false;
                                    
                                    
                                }
                                else
                                {
                                    //Console.WriteLine("unsafe:" + str + " steep " + i + " " + originalLine.Count);
                                    originalLine.RemoveAt(i + 1);
                                    safe = false;
                                    errorCounter++;
                                    errorCounter++;
                                    
                                    
                                }
                                loop--;
                                i = -1;
                                sortedlist = originalLine.ToArray();
                                sortedlist2 = originalLine.ToArray();
                                Array.Sort(sortedlist);
                                Array.Sort(sortedlist2);
                                Array.Reverse(sortedlist);
                            }
                            
                                if (originalLine.Where(x => x.Equals(originalLine[i])).Count() >= 2)
                                {
                                originalLine.Remove(originalLine[i]);
                                foreach (int asd in originalLine)
                                {
                                    Console.Write(asd);
                                }
                                
                                Console.WriteLine();
                                Console.WriteLine("unsafe:" + str + " little");
                                safe = false;
                                errorCounter++;
                                loop--;
                                i = -1;
                                sortedlist = originalLine.ToArray();
                                sortedlist2 = originalLine.ToArray();
                                Array.Sort(sortedlist);
                                Array.Sort(sortedlist2);
                                Array.Reverse(sortedlist);
                            }
                            
                            }

                        
                        if (safe == true)
                        {
                            //Console.WriteLine("safe:" + str);
                            safeCounter++;
                        }
                        else if (errorCounter == 1){
                            Console.Write("Safe with errors " + " ");
                            foreach (int asd in originalLine)
                            {
                                Console.Write(asd + " ");
                            }
                            Console.WriteLine();
                            foreach (int asd in originalLine2)
                            {
                                Console.Write(asd + " ");
                            }
                            Console.WriteLine();
                            safeCounter++;
                        }
                            
                    }
                    //Console.WriteLine(safeCounter);
                }

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
