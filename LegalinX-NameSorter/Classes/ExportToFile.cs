using System;
using System.Collections.Generic;
using System.IO;
using LegalinX_NameSorter.Interfaces;

namespace LegalinX_NameSorter.Classes
{
    /// <summary>
    /// Class to export list to file
    /// </summary>
    public class ExportToFile : IExportList, IDisposable
    {
        private string _exportFile;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="outputPath">The path to write the file to</param>
        public ExportToFile(string outputPath)
        {
            //  Generate the file name
            _exportFile = outputPath + Path.DirectorySeparatorChar + "sorted-names-list.txt";
        }

        /// <summary>
        /// Write the list out
        /// </summary>
        /// <param name="outputList">Output list.</param>
        public void WriteList(IList<string> outputList)
        {
            try
            {
                //  Create file
                using (TextWriter tw = new StreamWriter(_exportFile))
                {
                    //  Write each element to the file
                    foreach (var name in outputList)
                        tw.WriteLine(name.ToString());
                    tw.Close();
                }
            }
            catch
            {
                throw;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {

                }


                disposedValue = true;
            }
        }


        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
