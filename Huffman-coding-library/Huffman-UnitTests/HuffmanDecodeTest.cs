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

        [TestMethod]
        public void TestDecodeFile()
        {
            // Arrange
            var huffmanCoding = new HuffmanCoding();
            var encodedFilePath = Path.GetTempFileName();
            var EncodedText = huffmanCoding.EncodeText(OriginalText);
            File.WriteAllText(encodedFilePath, EncodedText);

            // Act

            var decodedText = huffmanCoding.DecodeFile(encodedFilePath);

            // Assert
            Assert.AreEqual(OriginalText, decodedText);

            // Clean up
            File.Delete(encodedFilePath);
        }

        [TestMethod]
        public void TestDecodeText()
        {
            // Arrange
            var huffmanCoding = new HuffmanCoding();
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
