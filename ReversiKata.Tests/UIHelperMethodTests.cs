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
        [Test]
        public void GetColorForLetterReturnsCorrectColor(string letter, ConsoleColor expectedColor)
        {
            Assert.AreEqual(expectedColor, m_UiHelperMethods.GetCellColorForLetter(letter));
        }

        [TestCase(ConsoleColor.White, CellState.White)]
        [TestCase(ConsoleColor.Black, CellState.Black)]
        [TestCase(ConsoleColor.Cyan, CellState.Empty)]
        [TestCase(ConsoleColor.DarkBlue, CellState.Empty)]
        [Test]
        public void GetCellStateForColor(ConsoleColor color, CellState expectedCellState)
        {
            Assert.AreEqual(expectedCellState, m_UiHelperMethods.GetCellStateForColor(color));
        }

        [TestCase("0",-1)]
        [TestCase("1",0)]
        [TestCase("8",7)]
        [TestCase("9",-1)]
        [TestCase("",-1)]
        [TestCase("100",-1)]
        [TestCase("A", -1)]
        [Test]
        public void GetColumnIndexReturnsCorrectValue(string column, int expectedIndex)
        {
            Assert.AreEqual(expectedIndex, m_UiHelperMethods.GetColumnIndex(column));   
        }

        [Test]
        [TestCase("a",0)]
        [TestCase("A", 0)]
        [TestCase("b", 1)]
        [TestCase("B", 1)]
        [TestCase("c", 2)]
        [TestCase("d", 3)]
        [TestCase("e", 4)]
        [TestCase("f", 5)]
        [TestCase("g", 6)]
        [TestCase("h", 7)]
        [TestCase("H", 7)]
        [TestCase("", -1)]
        [TestCase("i", -1)]
        [TestCase("zzz", -1)]
        public void GetRowIndexReturnsCorrectValue(string row, int expectedIndex)
        {
            Assert.AreEqual(expectedIndex, m_UiHelperMethods.GetRowIndex(row));
        }
    }
}
