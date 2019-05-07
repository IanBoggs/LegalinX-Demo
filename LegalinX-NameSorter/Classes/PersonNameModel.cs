using System;


namespace LegalinX_NameSorter.Classes
{
    /// <summary>
    /// Class For A Person
    /// </summary>
    public class PersonName
    {
        public string Surname { get; set; }
        public string FirstNames { get; set; }

        public override string ToString()
        {
            return $"{FirstNames} {Surname}".Trim();
        }
    }
}
