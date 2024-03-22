using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Huffman_coding;

namespace Huffman_Coding_Demo
{
    /// <summary>
    /// Interaktionslogik für EncodeDecodeText.xaml
    /// </summary>
    public partial class EncodeDecodeText : Window
    {
        private HuffmanCoding _huffmanCoding;
        public EncodeDecodeText()
        {
            InitializeComponent();
            _huffmanCoding = new HuffmanCoding();
        }

        private void EncryptButton_Click(object sender, RoutedEventArgs e)
        {
            string textToEncode = textBox.Text;

            if (!string.IsNullOrEmpty(textToEncode))
            {
                textBox.Text = _huffmanCoding.EncodeText(textToEncode);
            }
            else
            {
                MessageBox.Show("Please enter some text to encrypt.");
            }
        }

        private void DecryptButton_Click(object sender, RoutedEventArgs e)
        {
            string textToDecode = textBox.Text;

            if (!string.IsNullOrEmpty(textToDecode))
            {
                textBox.Text = _huffmanCoding.DecodeText(textToDecode);
            }
            else
            {
                MessageBox.Show("Please enter some text to Decrypt.");
            }
        }

        private void GithubButton_Click(object sender, RoutedEventArgs e)
        {
            // Open GitHub link in browser
            Process.Start(new ProcessStartInfo("https://github.com/Kurizaki/Huffman-coding/tree/master") { UseShellExecute = true });
        }
    }
}
