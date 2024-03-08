namespace Huffman_coding
{
    public class HuffmanTree
    {
        public static HuffmanNode BuildTree(Dictionary<char, int> frequencies)
        {
            var priorityQueue = new SortedDictionary<int, List<HuffmanNode>>();

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
            }

            return ExtractMin(priorityQueue);
        }

        private static HuffmanNode ExtractMin(SortedDictionary<int, List<HuffmanNode>> queue)
        {
            var minFrequency = queue.First().Key;
            var minNode = queue[minFrequency][0];
            queue[minFrequency].RemoveAt(0);

            if (queue[minFrequency].Count == 0)
                queue.Remove(minFrequency);

            return minNode;
        }
    }

}
