
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TouchSide.ScrabbleTests
{
    [TestClass]
    public class ScrabbleTest
    {
        private IScrabble _scrabble;
        
        [TestInitialize]
        public void TestInit()
        {
            _scrabble = new Scrabble();
        }

        [TestMethod]
        public void Lowercase_letter_A_shouldReturn_1()
        {
            Assert.AreEqual(1, _scrabble.Score("a"));
        }

        [TestMethod]
        public void Uppercase_letter_A_shouldReturn_1()
        {
            Assert.AreEqual(1, _scrabble.Score("A"));
        }

        [TestMethod]
        public void Letter_F_shouldReturn_4()
        {
            Assert.AreEqual(4, _scrabble.Score("f"));
        }

        [TestMethod]
        public void Short_word_at_shouldReturn_2()
        {
            Assert.AreEqual(2, _scrabble.Score("at"));
        }

        [TestMethod]
        public void Short_valuable_word_zoo_shouldReturn_12()
        {
            Assert.AreEqual(12, _scrabble.Score("zoo"));
        }

        [TestMethod]
        public void Medium_word_street_shouldReturn()
        {
            Assert.AreEqual(6, _scrabble.Score("street"));
        }

        [TestMethod]
        public void Medium_valuable_word_quirky_shouldReturn_22()
        {
            Assert.AreEqual(22, _scrabble.Score("quirky"));
        }

        [TestMethod]
        public void Long_mixed_case_word()
        {
            Assert.AreEqual(41, _scrabble.Score("OxyphenButazone"));
        }

        [TestMethod]
        public void English_like_word_pinata_shouldReturn_8()
        {
            Assert.AreEqual(8, _scrabble.Score("pinata"));
        }

        [TestMethod]
        public void Empty_input_empty_shouldReturn_0()
        {
            Assert.AreEqual(0, _scrabble.Score(""));
        }

        [TestMethod]
        public void Entire_alphabet_available_shouldReturn_87()
        {
            Assert.AreEqual(87, _scrabble.Score("abcdefghijklmnopqrstuvwxyz"));
        }
    }
}
