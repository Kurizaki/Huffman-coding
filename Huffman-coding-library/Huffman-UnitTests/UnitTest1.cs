using Huffman_coding;
namespace Huffman_UnitTests


{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void EncodeFileTest()
        {
            // Arrange
            string filepath = @"C:\Users\stefa\OneDrive\Desktop\Test.png";
            string originalText = File.ReadAllText(filepath);
            HuffmanCoding coding = new HuffmanCoding();
            coding.Initialize(originalText); 

            // Act
            string encodedText = coding.EncodeText(originalText);

            // Assert
            Assert.IsNotNull(encodedText);
        }
    }
}