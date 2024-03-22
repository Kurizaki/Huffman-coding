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
using System.Windows.Shapes;

namespace Huffman_Coding_Demo
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void ImportFileButton_Click(object sender, RoutedEventArgs e)
        {
            EncodeDecodeFile encodeDecodeFile = new EncodeDecodeFile();
            encodeDecodeFile.Show();
            this.Hide();
        }

        private void InsertTextButton_Click(object sender, RoutedEventArgs e)
        {
            EncodeDecodeText encodeDecodeText = new EncodeDecodeText();
            encodeDecodeText.Show();
            this.Hide();
        }

        private void GithubButton_Click(object sender, RoutedEventArgs e)
        {
            // Open GitHub link in browser
            Process.Start(new ProcessStartInfo("https://github.com/Kurizaki/Huffman-coding/tree/master") { UseShellExecute = true });
        }

        
    }
}
