using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using LegalinX_NameSorter.Classes;

namespace LegalinX_NameSorter
{


    class Program
    {

        /// <summary>
        /// Program Entry
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            try
            {
                //  Read and check cmdline params
                if (args.Length != 1)
                {
                    //  Inform incorrect args
                    Console.WriteLine("Incorrect number of parameters supplied");
                    return;
                }

                //  Get input file and confirm it exists
                string inputFile = args[0];
                if (!File.Exists(inputFile))
                {
                    Console.WriteLine($"File {inputFile} does not exist");
                    return;
                }

                //  Read in file
                List<string> fileData = File.ReadAllLines(inputFile).ToList();

                //  Create sorter class and add data
                NameSorter sorter = new NameSorter();
                sorter.AddNames(fileData);

                //  Export list to file
                using (var fileOut = new ExportToFile(Path.GetDirectoryName(inputFile)))
                {
                    fileOut.WriteList(sorter.SortedListOfNames);
                }

                //  Export list to console
                using (var conOut = new ExportToConsole())
                {
                    conOut.WriteList(sorter.SortedListOfNames);
                }


            }
            catch (Exception ex)
            {
                //  Report error to console
                Console.Write($"Error Processing List - {ex.Message}");
                return;
            }
        }

    }
}
