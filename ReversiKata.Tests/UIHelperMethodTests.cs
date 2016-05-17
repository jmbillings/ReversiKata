using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace ReversiKata.Tests
{
    [TestFixture]
    public class UIHelperMethodTests
    {
        private UIHelperMethods m_UiHelperMethods;

        [OneTimeSetUp]
        public void Setup()
        {
            m_UiHelperMethods = new UIHelperMethods();
        }

        [TestCase("b", ConsoleColor.Black)]
        [TestCase("w",ConsoleColor.White)]
        [TestCase("B", ConsoleColor.Black)]
        [TestCase("W", ConsoleColor.White)]
        [TestCase("a", ConsoleColor.Red)]
        [TestCase("z", ConsoleColor.Red)]
        [TestCase("ww", ConsoleColor.Red)]
        [TestCase("bb", ConsoleColor.Red)]
        public void GetColorForLetterReturnsCorrectColor(string letter, ConsoleColor expectedColor)
        {
            Assert.AreEqual(expectedColor, m_UiHelperMethods.GetCellColorForLetter(letter));
        }

        [TestCase(ConsoleColor.White, CellState.White)]
        [TestCase(ConsoleColor.Black, CellState.Black)]
        [TestCase(ConsoleColor.Cyan, CellState.Empty)]
        [TestCase(ConsoleColor.DarkBlue, CellState.Empty)]
        [TestCase(null, CellState.Empty)]
        public void GetCellStateForColor(ConsoleColor color, CellState expectedCellState)
        {
            Assert.AreEqual(expectedCellState, m_UiHelperMethods.GetCellStateForColor(color));
        }
    }
}
