using Huffman_coding;
namespace Huffman_UnitTests


{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void EncodeFileTest()
        {
            // Arrange
            string filepath = @"C:\Users\stefa\OneDrive\Desktop\Test.txt";
            string originalText = File.ReadAllText(filepath);
            HuffmanCoding coding = new HuffmanCoding();
            coding.Initialize(originalText); // Initialize with the content of the file

            // Act
            string encodedText = coding.EncodeText(originalText);

            // Assert
            Assert.IsNotNull(encodedText);
        }
    }
}