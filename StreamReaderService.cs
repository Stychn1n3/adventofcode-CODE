using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace adventofcode
{
    class StreamReaderService
    {
        public static List<String> EachLineAsList()
        {
            //Gets name of class calling the method I.E dayOne
            var methodInfo = new StackTrace().GetFrame(1).GetMethod();
            var className = methodInfo.ReflectedType.Name;

            List<String> fileOutput = File.ReadLines(className + "Input.txt").ToList();
            return fileOutput;
        }
    }
}
