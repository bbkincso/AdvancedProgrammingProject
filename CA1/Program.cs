using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace CA1
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder csvContent = new StringBuilder();
            string csvpath = "C:\\Users\\Kancsi\\Documents\\commit_changes.csv";

            string[] lines = File.ReadAllLines("C:\\Users\\Kancsi\\Documents\\commit_changes.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] != "" && !lines[i].Contains("/") && !lines[i].Contains("Changed paths:") && !lines[i].Contains("---"))
                {
                    lines[i] = lines[i].Replace(",", " ");
                    if (lines[i].StartsWith("r1"))
                    {
                        lines[i] = lines[i].Replace("|", ",");
                        csvContent.Append("\n");
                        
                    }
                        csvContent.Append(lines[i]+",");     
                }
            }
            File.AppendAllText(csvpath, csvContent.ToString());
            Console.WriteLine("File exported");
            Console.ReadLine();
        }
    }
}
