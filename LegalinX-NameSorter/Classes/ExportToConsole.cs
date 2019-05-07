using System;
using System.Collections.Generic;
using LegalinX_NameSorter.Interfaces;

namespace LegalinX_NameSorter.Classes
{
    /// <summary>
    /// Class to export list to console
    /// </summary>
    public class ExportToConsole : IExportList, IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public ExportToConsole()
        {
        }

        /// <summary>
        /// Write the list out
        /// </summary>
        /// <param name="outputList">Output list.</param>
        public void WriteList(IList<string> outputList)
        {
            try
            {
                //  Write each element to console
                foreach (var name in outputList)
                    Console.WriteLine(name.ToString());


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
