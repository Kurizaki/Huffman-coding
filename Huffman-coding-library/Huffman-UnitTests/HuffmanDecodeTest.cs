using Huffman_coding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman_UnitTests
{
    [TestClass]
    public class HuffmanDecodeTest
    {
        private const string OriginalText = "hello world";
        private const string EncodedText = "101010010010011111001011110111110010111010";

        [TestMethod]
        public void TestDecodeFile()
        {
            // Arrange
            var huffmanCoding = new HuffmanCoding(OriginalText);
            var encodedFilePath = Path.GetTempFileName();
            File.WriteAllText(encodedFilePath, EncodedText);

            // Act
            var decodedText = huffmanCoding.DecodeFile(encodedFilePath);

            // Assert
            Assert.AreEqual("lllrrdhredhrhl", decodedText);

            // Clean up
            File.Delete(encodedFilePath);
        }

        [TestMethod]
        public void TestDecodeText()
        {
            // Arrange
            var huffmanCoding = new HuffmanCoding(OriginalText);
            var encodedText = huffmanCoding.EncodeText(OriginalText);
            var targetFilePath = Path.GetTempFileName();

            // Act
            var decodedText = huffmanCoding.DecodeText(encodedText, targetFilePath);
            var decodedFromFile = File.ReadAllText(targetFilePath);

            // Assert
            Assert.AreEqual(OriginalText, decodedText);
            Assert.AreEqual(OriginalText, decodedFromFile);

            // Clean up
            File.Delete(targetFilePath);
        }
    }
}
