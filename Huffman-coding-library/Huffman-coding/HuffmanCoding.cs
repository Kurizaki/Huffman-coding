﻿using System.Text;
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
                if (!_encodingTable.ContainsKey(c))
                    throw new InvalidOperationException($"Character '{c}' not found in encoding table.");
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

                currentNode = bit == '0' ? currentNode.Left : currentNode.Right;
                if (currentNode?.Left == null && currentNode?.Right == null)
                {
                    decodedText.Append(currentNode?.Character);
                    currentNode = _root;
                }
            }

            return decodedText.ToString();
        }

        /// <summary>
        /// Initializes the Huffman coding process with the given text.
        /// </summary>
        /// <param name="text">The text to be encoded/decoded.</param>
        public void Initialize(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Text cannot be null or empty.", nameof(text));

            var frequencies = CalculateFrequencies(text);
            _root = HuffmanTree.BuildTree(frequencies);
            BuildEncodingTable(_root, "");
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
                Initialize(text);
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

            using (var streamReader = new StreamReader(filepath))
            {
                var text = streamReader.ReadToEnd();
                var encodedText = EncodeText(text);

                var encodedFilePath = Path.ChangeExtension(filepath, ".hfc");
                File.WriteAllText(encodedFilePath, encodedText);

                return encodedFilePath;
            }
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