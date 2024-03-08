﻿namespace Huffman_coding
{
    public class HuffmanCoding
    {
        private Dictionary<char, string> _encodingTable = new Dictionary<char, string>();
        private HuffmanNode _root;

        public HuffmanCoding(string text)
        {
            var frequencies = CalculateFrequencies(text);
            _root = HuffmanTree.BuildTree(frequencies);
            BuildEncodingTable(_root, "");
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

        public string EncodeText(string text)
        {
            var encodedText = "";

            foreach (var c in text)
            {
                encodedText += _encodingTable[c];
            }

            return encodedText;
        }

        public string Decode(string encodedText)
        {
            var decodedText = "";
            var currentNode = _root;

            foreach (var bit in encodedText)
            {
                currentNode = bit == '0' ? currentNode.Left : currentNode.Right;
                if (currentNode.Left == null && currentNode.Right == null)
                {
                    decodedText += currentNode.Character;
                    currentNode = _root;
                }
            }

            return decodedText;
        }
    }

}