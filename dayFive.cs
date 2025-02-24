using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace adventofcode
{
    class dayFive
    {
        //non-changing vars
        private static char delmiter = '|';
        private static char delmiter2 = ',';

        public static void dayFiveMethod()
        {
            List<string> reportline = new List<string>();
            List<string> rules = new List<string>();
            List<string> pages = new List<string>();

            int middlePageTotal = 0;
            int middlePageTotal2 = 0;
            int middlePageTotal3 = 0;

            List<string> fileOutput = StreamReaderService.EachLineAsList();

            //separate rules and pages
            rules = fileOutput.Where(s => s.Contains('|')).ToList();
            pages = fileOutput.Where(s => !s.Contains('|')).ToList();

            //sort pages
            foreach (string pageLine in pages)
            {
                var sortedValues = sortPages(pageLine, rules);

                bool alreadyCorrect = sortedValues.Item1;
                string[] pages2 = sortedValues.Item2;

                //adds to different page totals depending on if it was already correct, the total for only correct page lines or the total of all regardless
                if (alreadyCorrect)
                {
                    middlePageTotal += int.Parse(pages2[pages2.Length / 2]);
                }
                else
                {
                    middlePageTotal3 += int.Parse(pages2[pages2.Length / 2]);
                }

                middlePageTotal2 += int.Parse(pages2[pages2.Length / 2]);
            }

            printResults(middlePageTotal, middlePageTotal3, middlePageTotal2);
        }

        private static void printResults(int middlePageTotal, int middlePageTotal3, int middlePageTotal2)
        {
            //outputs everything
            Console.WriteLine("Already Correct Total: " + middlePageTotal);
            Console.WriteLine("Fixed Correct Total: " + middlePageTotal3);
            Console.WriteLine("Absolute Total: " + middlePageTotal2);
        }

        private static Tuple<bool, string[]> sortPages(string pageLine, List<string> rules)
        {
            string[] pages;
            string[] buffer;

            //Assumes the pages are already sorted cause 'murica
            bool alreadyCorrect = true;
            pages = pageLine.Split(delmiter2);
            int errors = rules.Count;

            while (errors > 0)
            {
                foreach (string s in rules)
                {
                    buffer = s.Split(delmiter);
                    string rule1 = buffer[0];
                    string rule2 = buffer[1];

                    if (pageLine.Contains(rule1) && pageLine.Contains(rule2))
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
            }
            return Tuple.Create(alreadyCorrect, pages);
        }
    }
}
