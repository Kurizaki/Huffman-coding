using Huffman_coding;
namespace Huffman_UnitTests


{
    [TestClass]
    public class UnitTest1
    {
        

        [TestMethod]
        public void EncodeFileTest()
        {
            //Arrange
            string filepath = @"C:\Users\stefa\OneDrive\Desktop\Test.txt";
            string expected = "11101111101000000101001110110";
            HuffmanCoding coding = new HuffmanCoding();

            //Act
             string actual = coding.EncodeFile(filepath);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}