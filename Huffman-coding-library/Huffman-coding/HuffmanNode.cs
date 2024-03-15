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
    /// Represents a node in a Huffman tree.
    /// </summary>
    public class HuffmanNode
    {
        /// <summary>
        /// Gets or sets the character associated with the node.
        /// </summary>
        public char Character { get; set; }

        /// <summary>
        /// Gets or sets the frequency of the character in the input data.
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// Gets or sets the left child node of the current node.
        /// </summary>
        public HuffmanNode Left { get; set; }

        /// <summary>
        /// Gets or sets the right child node of the current node.
        /// </summary>
        public HuffmanNode Right { get; set; }
    }
}
