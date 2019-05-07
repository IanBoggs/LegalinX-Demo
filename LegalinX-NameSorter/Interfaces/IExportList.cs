using System;
using System.Collections.Generic;
using LegalinX_NameSorter.Classes;

namespace LegalinX_NameSorter.Interfaces
{
    /// <summary>
    /// Interface for exporting
    /// </summary>
    public interface IExportList
    {
        void WriteList(IList<string> outputList);
    }
}
