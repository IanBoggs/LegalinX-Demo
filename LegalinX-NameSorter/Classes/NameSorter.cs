using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace LegalinX_NameSorter.Classes
{
    /// <summary>
    /// Class to hold names in a sorted list.
    /// </summary>
    public class NameSorter
    {
        /// <summary>
        /// Holds main list of names
        /// </summary>
        private List<PersonName> _listOfNames;

        /// <summary>
        /// Accessor property 
        /// </summary>
        /// <value>The list of names</value>
        public IList<string> SortedListOfNames { get => _listOfNames.OrderBy(n => n.Surname).ThenBy(n => n.FirstNames).Select(n => n.ToString()).ToList(); }

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public NameSorter()
        {
            //  Initialise list
            _listOfNames = new List<PersonName>();
        }

        public bool AddNames(List<string> listOfNames)
        {
            foreach (var name in listOfNames)
            {
                if (!AddName(name))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Add name to the list
        /// </summary>
        /// <param name="fullName">Name to add to the list</param>
        public bool AddName(string fullName)
        {
            try
            {
                PersonName person;
                //  Create name object to add
                int idx = fullName.LastIndexOf(' ');
                if (idx != -1)
                    person = new PersonName { FirstNames = fullName.Substring(0, idx), Surname = fullName.Substring(idx + 1) };
                else
                    person =  new PersonName { FirstNames = string.Empty, Surname = fullName };
                //  Add name to the list
                _listOfNames.Add(person);
                return true;
            }
            catch 
            {
                return false;
            }
        }
    }
}
