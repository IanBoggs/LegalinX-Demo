using Microsoft.VisualStudio.TestTools.UnitTesting;
using LegalinX_NameSorter.Classes;
using System.Collections.Generic;
using System.Linq;

namespace LegalinX_NameSorterTests
{
    [TestClass]
    public class NameSorterTest
    {
        
        public NameSorterTest()
        {
            
        }


        /// <summary>
        /// Provides test data for the test methods
        /// </summary>
        /// <remarks>List of names and the position the name should appear in when sorted</remarks>
        public static IEnumerable<object[]> GetTestData
        {
            get
            {
                return new[]
                {
                     new object[] {"Ian Boggs",1 },
                     new object[] {"Mo Salah" ,5},
                     new object[] {"Virgil van Dijk",2 },
                     new object[] {"Jordan Henderson" ,4},
                     new object[] {"Fabinho",3 }
                };
            }
        }

        /// <summary>
        /// Provides test data for testing duplicate data
        /// </summary>
        /// <remarks>List of names and the position the name should appear in when sorted</remarks>
        public static IEnumerable<object[]> SameSurnameData

        {
            get
            {
                return new[]
                {
                     new object[] {"Ian Boggs",2 },
                     new object[] {"Claire Boggs" ,1}
                };
            }
        }

        [TestMethod]
        [DynamicData(nameof(GetTestData))]
        public void AddName_AddName_NameAdded(string name, int order)
        {
            //  Arrange
            var sorter = new NameSorter();

            //  Act
            var result = sorter.AddName(name);

            //  Assert
            Assert.IsTrue(result);
        }


        /// <summary>
        /// Test whether names are added to the object without error
        /// </summary>
        [TestMethod]
        public void AddNames_AddListOfNames_NamesAdded()
        {
            //  Arrange
            var sorter  = new NameSorter();
            List<string> names = GetTestData.Select(x => x[0].ToString()).ToList();

            //  Act
            var result = sorter.AddNames(names);

            //  Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test whether names are added to the object without error
        /// </summary>
        [TestMethod]
        public void AddNames_AddListOfNames_CheckAllAdded()
        {
            //  Arrange
            var sorter = new NameSorter();
            List<string> names = GetTestData.Select(x => x[0].ToString()).ToList();

            //  Act
            var result = sorter.AddNames(names);

            //  Assert
            Assert.IsTrue(sorter.SortedListOfNames.Count == names.Count);
        }

        /// <summary>
        /// Test method to confirm that list is ordered correctly
        /// </summary>
        [TestMethod]
        public void ListOfNames_CheckOrder_CorrectOrder()
        {
            //  Arrange
            var sorter = new NameSorter();
            List<string> names = GetTestData.Select(x => x[0].ToString()).ToList();
            List<string> expectedOrder = GetTestData.OrderBy(x => x[1]).Select(x => x[0].ToString()).ToList();


            //  Act
            sorter.AddNames(names);

            //  Assert
            CollectionAssert.AreEqual(expectedOrder, sorter.SortedListOfNames.ToList());
        }

        [TestMethod]
        public void ListOfNames_AddSameSurname_CanBeAdded()

        {
            //  Arrange
            var sorter = new NameSorter();
            List<string> names = SameSurnameData.Select(x => x[0].ToString()).ToList();

            //  Act
            var result = sorter.AddNames(names);

            //  Assert
            Assert.IsTrue(result);

        }
    }
}
