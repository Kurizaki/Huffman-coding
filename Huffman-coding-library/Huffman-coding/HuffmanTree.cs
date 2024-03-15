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
    /// Represents a Huffman tree data structure and provides methods for building the tree.
    /// </summary>
    public class HuffmanTree
    {
        /// <summary>
        /// Indicates whether protocol messages should be displayed.
        /// </summary>
        public static bool ShowProtocol;

        /// <summary>
        /// Builds a Huffman tree based on character frequencies.
        /// </summary>
        /// <param name="frequencies">A dictionary containing characters as keys and their frequencies as values.</param>
        /// <returns>The root node of the Huffman tree.</returns>
        public static HuffmanNode BuildTree(Dictionary<char, int> frequencies)
        {
            // Represents a priority queue implemented as a sorted dictionary.
            var priorityQueue = new SortedDictionary<int, List<HuffmanNode>>();

            // Populates the priority queue with nodes for each character frequency.
            foreach (var kvp in frequencies)
            {
                var node = new HuffmanNode
                {
                    Character = kvp.Key,
                    Frequency = kvp.Value
                };

                if (!priorityQueue.ContainsKey(node.Frequency))
                    priorityQueue[node.Frequency] = new List<HuffmanNode>();

                priorityQueue[node.Frequency].Add(node);
            }

            // Merges nodes to build the Huffman tree.
            while (priorityQueue.Count > 1)
            {
                var firstNode = ExtractMin(priorityQueue);
                var secondNode = ExtractMin(priorityQueue);

                var mergedNode = new HuffmanNode
                {
                    Frequency = firstNode.Frequency + secondNode.Frequency,
                    Left = firstNode,
                    Right = secondNode
                };

                if (!priorityQueue.ContainsKey(mergedNode.Frequency))
                    priorityQueue[mergedNode.Frequency] = new List<HuffmanNode>();

                priorityQueue[mergedNode.Frequency].Add(mergedNode);

                // Displays protocol message if enabled.
                if (ShowProtocol)
                {
                    Console.WriteLine($"[HuffmanTree] {DateTime.Now} Protocol: Merged nodes with frequencies {firstNode.Frequency} and {secondNode.Frequency}. New frequency: {mergedNode.Frequency}");
                }
            }

            return ExtractMin(priorityQueue);
        }

        /// <summary>
        /// Extracts the node with the minimum frequency from the priority queue.
        /// </summary>
        /// <param name="queue">The priority queue containing lists of nodes grouped by frequency.</param>
        /// <returns>The node with the minimum frequency.</returns>
        private static HuffmanNode ExtractMin(SortedDictionary<int, List<HuffmanNode>> queue)
        {
            var minFrequency = queue.First().Key;
            var minNode = queue[minFrequency][0];
            queue[minFrequency].RemoveAt(0);

            if (queue[minFrequency].Count == 0)
                queue.Remove(minFrequency);

            // Displays protocol message if enabled.
            if (ShowProtocol)
            {
                Console.WriteLine($"[HuffmanTree] {DateTime.Now} Protocol: Extracted node with frequency {minNode.Frequency}");
            }

            return minNode;
        }
    }
}
