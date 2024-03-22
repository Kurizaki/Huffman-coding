using Huffman_coding;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace Huffman_UnitTests
{
    [TestClass]
    public class HuffmanEncodeTest
    {
        private const string OriginalText = "hello world";

        [TestMethod]
        public void EncodeFileTest()
        {
            var extensions = new List<string> { ".txt", ".json", ".yaml", ".yml", ".xml", ".csv", ".html", ".css" };

            foreach (var extension in extensions.ToArray()) // ToArray() is used to create a copy of the list to avoid modification during iteration
            {
                // Arrange
                var huffmanCoding = new HuffmanCoding();
                var encodedFilePath = Path.ChangeExtension(Path.GetTempFileName(), extension);
                File.WriteAllText(encodedFilePath, OriginalText);

                // Act
                string encodedTextFilePath = huffmanCoding.EncodeFile(encodedFilePath);
                string encodedText = File.ReadAllText(encodedTextFilePath);

                // Assert
                Assert.AreEqual(OriginalText, huffmanCoding.DecodeFile(encodedTextFilePath));

                // Clean up
                File.Delete(encodedFilePath);
                File.Delete(encodedTextFilePath);

                // Remove the extension from the list to mark it as tested
                extensions.Remove(extension);
            }

            // Ensure that all extensions have been tested
            Assert.AreEqual(0, extensions.Count);
        }

        [TestMethod]
        public void EncodeTextTest()
        {
            // Arrange
            var huffmanCoding = new HuffmanCoding();

            // Act
            string encodedText = huffmanCoding.EncodeText(OriginalText);

            // Assert
            Assert.AreEqual(OriginalText, huffmanCoding.DecodeText(encodedText, Path.GetTempFileName()));
        }
    }
}