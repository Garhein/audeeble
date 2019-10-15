using Microsoft.VisualStudio.TestTools.UnitTesting;
using Audeeble_Shared.Helpers;
using System.Collections.Generic;

namespace Audeeble_Tests.Shared.Helpers
{
    [TestClass]
    public class EnumerableHelperTests
    {
        // TODO:
        //      -> mettre des messages plus précis
        //      -> commentaires sur les méthodes
        //      -> déclencher les tests à la build ?
        
        [TestMethod]
        public void EnumerableIsEmpty_Null_True() 
        {
            List<int> listeToTest = null;
            Assert.IsTrue(listeToTest.IsEmpty(), "IEnumerable non vide.");
        }

        [TestMethod]
        public void EnumerableIsEmpty_NotNull_Empty_True()
        {
            List<string> listeToTest = new List<string>();
            Assert.IsTrue(listeToTest.IsEmpty(), "IEnumerable non vide.");
        }

        [TestMethod]
        public void EnumerableIsEmpty_NotNull_NotEmpty_False()
        {
            List<int> listeToTest = new List<int> { 1, 2, 3, 4, 5 };
            Assert.IsFalse(listeToTest.IsEmpty(), "IEnumerable vide.");
        }
    }
}
