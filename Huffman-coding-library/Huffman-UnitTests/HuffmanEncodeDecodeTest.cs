using Huffman_coding;

namespace Huffman_UnitTests
{
    [TestClass]
    public class HuffmanEncodeDecodeTest
    {
        private const string OriginalText = "hello world";
        [TestMethod]
        public void EncodeDecodeFileTest()
        {
            var extensions = new List<string> { ".txt", ".json", ".yaml", ".yml", ".xml", ".csv", ".html", ".css" };

            foreach (var extension in extensions.ToArray())
            {
                // Arrange
                var huffmanCoding = new HuffmanCoding();
                var encodedFilePath = Path.ChangeExtension(Path.GetTempFileName(), extension);
                File.WriteAllText(encodedFilePath, OriginalText);

                // Act
                string encodedTextFilePath = huffmanCoding.EncodeFile(encodedFilePath);
                string encodedText = File.ReadAllText(encodedTextFilePath);
                string decodedText = huffmanCoding.DecodeFile(encodedTextFilePath);

                // Assert
                Assert.AreEqual(OriginalText, decodedText);

                // Clean up
                File.Delete(encodedFilePath);
                File.Delete(encodedTextFilePath);

                // Remove the extension from the list to mark it as tested
                extensions.Remove(extension);
            }

            // Ensure that all extensions have been tested
            Assert.AreEqual(0, extensions.Count);
        }
    }
}
