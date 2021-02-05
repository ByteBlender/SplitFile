using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SplitFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Drop the input file here:");
            string fileName = Console.ReadLine().Replace("\"", "");
            Console.WriteLine("\n");
            Console.Write("Record limit:");
            int recordLimit = int.Parse( Console.ReadLine());

            string[] sourceFile = File.ReadAllLines(fileName);

            int fileCount = 1;
            List<string> spliFile = new List<string>();
            for (int i = 0; i < sourceFile.Length; i++)
            {

                spliFile.Add(sourceFile[i]);

                if (i == sourceFile.Length-1)
                {
                    File.WriteAllLines(fileName.Replace(".txt", $"_{fileCount}.txt"), spliFile.ToArray());
                    break;
                }

           

                if((i+1) % recordLimit == 0 && i>0)
                {
                    File.WriteAllLines(fileName.Replace(".txt", $"_{fileCount}.txt"), spliFile.ToArray());
                    fileCount++;
                    spliFile.Clear();
                }

               
            }

        }
    }
}
