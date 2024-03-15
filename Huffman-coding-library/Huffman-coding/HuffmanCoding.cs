using System.ComponentModel.Design;
using System.Text;
/*
  ___  ___  ___  ___  ________ ________ _____ ______   ________  ________           ________  ________  ________  ___  ________   ________
 |\  \|\  \|\  \|\  \|\  _____\\  _____\\   _ \  _   \|\   __  \|\   ___  \        |\   ____\|\   __  \|\   ___ \|\  \|\   ___  \|\   ____\
 \ \  \\\  \ \  \\\  \ \  \__/\ \  \__/\ \  \\\__\ \  \ \  \|\  \ \  \\ \  \       \ \  \___|\ \  \|\  \ \  \_|\ \ \  \ \  \\ \  \ \  \___|
  \ \   __  \ \  \\\  \ \   __\\ \   __\\ \  \\|__| \  \ \   __  \ \  \\ \  \       \ \  \    \ \  \\\  \ \  \ \\ \ \  \ \  \\ \  \ \  \  ___
   \ \  \ \  \ \  \\\  \ \  \_| \ \  \_| \ \  \    \ \  \ \  \ \  \ \  \\ \  \       \ \  \____\ \  \\\  \ \  \_\\ \ \  \ \  \\ \  \ \  \|\  \
    \ \__\ \__\ \_______\ \__\   \ \__\   \ \__\    \ \__\ \__\ \__\ \__\\ \__\       \ \_______\ \_______\ \_______\ \__\ \__\\ \__\ \_______\
     \|__|\|__|\|_______|\|__|    \|__|    \|__|     \|__|\|__|\|__|\|__| \|__|        \|_______|\|_______|\|_______|\|__|\|__| \|__|\|_______|
Authors: Keanu Koelewijn, Stefan Jesenko, Salma Tanner
*/

namespace Huffman_coding
{
    public class HuffmanCoding
    {
        private Dictionary<char, string> _encodingTable;
        private HuffmanNode _root;
        public bool ShowProtocol;

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
                if (ShowProtocol)
                {
                    Console.WriteLine($"[HuffmanCoding] {DateTime.Now} Protocol: The Frequency of '{c}' is {frequencies[c]}");
                }
            }

            return frequencies;
        }

        private void BuildEncodingTable(HuffmanNode node, string prefix)
        {
            if (node.Left == null && node.Right == null)
            {
                _encodingTable[node.Character] = prefix;
                if (ShowProtocol)
                {
                    Console.WriteLine($"[HuffmanCoding] {DateTime.Now} Protocol: Encoding for '{node.Character}' is '{prefix}'");
                }
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

            if (ShowProtocol)
            {
                Console.WriteLine($"[HuffmanCoding] {DateTime.Now} Protocol: The Encoded Text is '{encodedText}'");
            }

            return encodedText.ToString();
        }

        private string Decode(string encodedText)
        {
            var decodedText = new StringBuilder();
            var currentNode = _root;

            foreach (var bit in encodedText)
            {
                currentNode = bit == '0' ? currentNode.Left : currentNode.Right;
                if (currentNode.Left == null && currentNode.Right == null)
                {
                    decodedText.Append(currentNode.Character);
                    currentNode = _root;
                }
            }

            return decodedText.ToString();
        }

        public void Initialize(string text)
        {
            var frequencies = CalculateFrequencies(text);
            _root = HuffmanTree.BuildTree(frequencies);
            BuildEncodingTable(_root, "");
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

                var text = "";
                if (CheckFileExtension(filepath))
                {
                    text = streamReader.ReadToEnd();
                }
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
            
            var encodedText = "";
            
            if (Path.GetExtension(sourcePath) == ".hfc")
            {
                using (var streamReader = new StreamReader(sourcePath))
                {
                    encodedText = streamReader.ReadToEnd();

                }
            }else
            {
                throw new Exception("File isn't a .hfc");
            }

            return Decode(encodedText);
        }

        public bool CheckFileExtension(string filePath)
        {
            string[] validExtensions = { ".txt", ".json", ".yaml", ".yml", ".xml", ".csv", ".html", ".css" };
            string extension = Path.GetExtension(filePath);
            bool isValidExtension = Array.Exists(validExtensions, ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase));

            if (!isValidExtension)
            {
                throw new Exception("File isn't a .txt, .json, .yaml, .yml, .xml, .csv, .html, or .css");
            }

            return isValidExtension;
        }
    }
}