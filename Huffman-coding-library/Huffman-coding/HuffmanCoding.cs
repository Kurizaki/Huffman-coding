using System.Text;

namespace Huffman_coding
{
    public class HuffmanCoding
    {
        private Dictionary<char, string> _encodingTable;
        private HuffmanNode _root;

        public HuffmanCoding()
        {
            _encodingTable = new Dictionary<char, string>();
        }

        private Dictionary<char, int> CalculateFrequencies(string text)
        {
            var frequencies = new Dictionary<char, int>();

            foreach (var c in text)
            {
                if (!frequencies.ContainsKey(c))
                    frequencies[c] = 0;
                frequencies[c]++;

            }
            Console.WriteLine(frequencies);

            return frequencies;
        }

        private void BuildEncodingTable(HuffmanNode node, string prefix)
        {
            if (node.Left == null && node.Right == null)
            {
                _encodingTable[node.Character] = prefix;
                return;
            }

            BuildEncodingTable(node.Left, prefix + "0");
            BuildEncodingTable(node.Right, prefix + "1");
        }

        private string Encode(string text)
        {
            var encodedText = new StringBuilder();

            foreach (var c in text)
            {
                encodedText.Append(_encodingTable[c]);
            }
            Console.WriteLine(encodedText);

            return encodedText.ToString();
        }

        private string Decode(string encodedText)
        {
            string extension = Path.GetExtension(filepath);
            string text = "";
            var encodedText = "";
            if (extension == ".txt")
            {
               text = File.ReadAllText(filepath);
            }
            else
            {
                throw new Exception("file is not a .txt");
            }
           
            foreach (var c in text)
            {
                encodedText += _encodingTable[c];
            }
            Console.WriteLine(encodedText);
            return encodedText;
        }

        public string EncodeText(string text)
        {
            if (_encodingTable.Count == 0)
                Initialize(text);
            return Encode(text);
        }

        public string EncodeFile(string filepath)
        {
            using (var streamReader = new StreamReader(filepath))
            {
                var text = streamReader.ReadToEnd();
                return EncodeText(text);
            }
        }

        public string DecodeText(string encodedText, string targetPath)
        {
            var decodedText = Decode(encodedText);
            File.WriteAllText(targetPath, decodedText);
            return decodedText;
        }

        public string DecodeFile(string sourcePath)
        {
            using (var streamReader = new StreamReader(sourcePath))
            {
                var encodedText = streamReader.ReadToEnd();
                return Decode(encodedText);
            }
        }
    }
}
