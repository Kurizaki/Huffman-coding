using Huffman_coding;
namespace Huffman_UnitTests


{
    [TestClass]
    public class HuffmanEncodeTest
    {
        private const string OriginalText = "hello world";
        private const string expected = "11101111101011000000111001010011";

        [TestMethod]
        public void EncodeFileTest()
        {

            // Arrange
            var huffmanCoding = new HuffmanCoding();
            var encodedFilePath = Path.GetTempFileName();
            File.WriteAllText(encodedFilePath, OriginalText);
            // Act
            string encodedText = huffmanCoding.EncodeFile(encodedFilePath);

            // Assert
            Assert.AreEqual(expected, encodedText);
            // Clean up
            File.Delete(encodedFilePath);
        }
        [TestMethod]
        public void EncodeTextTest()
        {
            // Arrange
            var huffmanCoding = new HuffmanCoding();
            // Act
            string encodedText = huffmanCoding.EncodeText(OriginalText);

            // Assert
            Assert.AreEqual(expected, encodedText);
        }
    }
}