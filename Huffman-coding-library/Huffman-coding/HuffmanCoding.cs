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
    /// <summary>
    /// Provides methods for Huffman coding, including encoding and decoding text and files.
    /// </summary>
    public class HuffmanCoding
    {
        private Dictionary<char, string> _encodingTable;
        private HuffmanNode _root;
        public bool ShowProtocol;

        /// <summary>
        /// Initializes a new instance of the <see cref="HuffmanCoding"/> class.
        /// </summary>
        public HuffmanCoding()
        {
            _encodingTable = new Dictionary<char, string>();
        }

        /// <summary>
        /// Calculates the frequencies of characters in the given text.
        /// </summary>
        /// <param name="text">The text for which frequencies are to be calculated.</param>
        /// <returns>A dictionary containing characters as keys and their frequencies as values.</returns>
        /// <exception cref="ArgumentNullException">Thrown when the input text is null.</exception>
        private Dictionary<char, int> CalculateFrequencies(string text)
        {
            if (text == null)
                throw new ArgumentNullException(nameof(text), "Input text cannot be null.");

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

        /// <summary>
        /// Builds the Huffman encoding table starting from the root node.
        /// </summary>
        /// <param name="node">The current node in the Huffman tree.</param>
        /// <param name="prefix">The prefix representing the encoding of characters.</param>
        /// <exception cref="ArgumentNullException">Thrown when the node is null.</exception>
        private void BuildEncodingTable(HuffmanNode node, string prefix)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node), "Node cannot be null.");

            // If the node represents a leaf (i.e., a character), add its encoding to the table
            if (node.Left == null && node.Right == null)
            {
                _encodingTable[node.Character] = prefix;
                if (ShowProtocol)
                {
                    Console.WriteLine($"[HuffmanCoding] {DateTime.Now} Protocol: Encoding for '{node.Character}' is '{prefix}'");
                }
                return;
            }

            // Traverse down the left subtree and append '0' to the prefix
            BuildEncodingTable(node.Left, prefix + "0");

            // If the node has a non-null right child, traverse down the right subtree and append '1' to the prefix
            if (node.Right != null)
            {
                BuildEncodingTable(node.Right, prefix + "1");
            }
        }

        private string Encode(string text)
        {
            var encodedText = new StringBuilder();

            foreach (var c in text)
            {
                // Check if the encoding table contains a mapping for the character
                if (!_encodingTable.ContainsKey(c))
                {
                    // Handle case where character is not found in the encoding table
                    throw new InvalidOperationException($"Character '{c}' not found in encoding table.");
                }

                // Append the encoded bits for the character to the result
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
                if (currentNode == null)
                    throw new InvalidOperationException("Invalid Huffman encoding.");

                // Navigate through the Huffman tree based on the encoded bits
                currentNode = bit == '0' ? currentNode.Left : currentNode.Right;

                // Check if the current node represents a character leaf node
                if (currentNode?.Left == null && currentNode?.Right == null)
                {
                    // Append the decoded character to the result
                    if (currentNode?.Character != null)
                    {
                        decodedText.Append(currentNode.Character);
                        currentNode = _root; // Reset back to the root for the next character
                    }
                    else
                    {
                        // Handle case where decoded character is null (not found in encoding table)
                        throw new InvalidOperationException("Character not found in encoding table.");
                    }
                }
            }

            return decodedText.ToString();
        }

        /// <summary>
        /// Encodes the given text using Huffman coding.
        /// </summary>
        /// <param name="text">The text to be encoded.</param>
        /// <returns>The encoded text.</returns>
        public string EncodeText(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be null or empty.", nameof(text));

            if (_encodingTable.Count == 0)
            {
                var frequencies = CalculateFrequencies(text);
                _root = HuffmanTree.BuildTree(frequencies);
                BuildEncodingTable(_root, "");
            }

            return Encode(text);
        }

        /// <summary>
        /// Encodes a text file using Huffman coding.
        /// </summary>
        /// <param name="filepath">The path to the text file to be encoded.</param>
        /// <returns>The path to the encoded file.</returns>
        public string EncodeFile(string filepath)
        {
            if (string.IsNullOrWhiteSpace(filepath))
                throw new ArgumentException("Filepath cannot be null or empty.", nameof(filepath));

            if (!File.Exists(filepath))
                throw new FileNotFoundException("File not found.", filepath);

            if (!CheckFileExtension(filepath))
                throw new InvalidOperationException("File extension is not supported for encoding.");

            // Read the text from the file
            string text;
            using (var streamReader = new StreamReader(filepath))
            {
                text = streamReader.ReadToEnd();
            }

            // Encode the text using Huffman coding
            var encodedText = EncodeText(text);

            // Write the encoded text to a new file with the .hfc extension
            var encodedFilePath = Path.ChangeExtension(filepath, ".hfc");
            File.WriteAllText(encodedFilePath, encodedText);

            return encodedFilePath;
        }

        /// <summary>
        /// Decodes the given encoded text.
        /// </summary>
        /// <param name="encodedText">The text to be decoded.</param>
        /// <returns>The decoded text.</returns>
        public string DecodeText(string encodedText)
        {
            if (string.IsNullOrWhiteSpace(encodedText))
                throw new ArgumentException("Encoded text cannot be null or empty.", nameof(encodedText));

            // Decode the encoded text using Huffman coding
            return Decode(encodedText);
        }

        /// <summary>
        /// Decodes a file encoded with Huffman coding.
        /// </summary>
        /// <param name="sourcePath">The path to the encoded file.</param>
        /// <returns>The decoded text.</returns>
        public string DecodeFile(string sourcePath)
        {
            if (string.IsNullOrWhiteSpace(sourcePath))
                throw new ArgumentException("Source path cannot be null or empty.", nameof(sourcePath));

            if (!File.Exists(sourcePath))
                throw new FileNotFoundException("File not found.", sourcePath);

            string encodedText;

            // Read the encoded text from the file
            if (Path.GetExtension(sourcePath) == ".hfc")
            {
                using (var streamReader = new StreamReader(sourcePath))
                {
                    encodedText = streamReader.ReadToEnd();
                }
            }
            else
            {
                throw new InvalidOperationException("File format is not supported for decoding.");
            }

            // Decode the encoded text using Huffman coding
            return Decode(encodedText);
        }

        /// <summary>
        /// Checks if the given file has a valid extension.
        /// </summary>
        /// <param name="filePath">The path to the file.</param>
        /// <returns>True if the file has a valid extension, otherwise false.</returns>
        public bool CheckFileExtension(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Filepath cannot be null or empty.", nameof(filePath));

            string[] validExtensions = { ".txt", ".json", ".yaml", ".yml", ".xml", ".csv", ".html", ".css" };
            string extension = Path.GetExtension(filePath);
            bool isValidExtension = Array.Exists(validExtensions, ext => ext.Equals(extension, StringComparison.OrdinalIgnoreCase));

            if (!isValidExtension)
            {
                throw new InvalidOperationException("File extension is not supported.");
            }

            return isValidExtension;
        }
    }
}