### Huffman Coding Library

This library provides robust functionality for implementing Huffman coding, a renowned compression algorithm widely utilized for text compression tasks. With this package, you can:

- Encode plain text efficiently, employing Huffman coding's technique of replacing frequently occurring characters with shorter binary representations.
- Encode entire text files, effectively compressing substantial amounts of text data into smaller, more manageable files, ideal for storage or transmission.
- Decode previously encoded text, effortlessly reverting the compression process and restoring the original content.
- Decode previously encoded files, allowing seamless recovery of the original text from Huffman encoded files.
- Ensure file integrity with a utility method for checking file extensions, ensuring compatibility and safeguarding against processing unsupported file types.
- Optionally enable protocol logging to track the encoding process, providing invaluable insights into frequency calculation, encoding table generation, and encoded text output for debugging and monitoring purposes.

### Encode File:
```csharp
var huffmanCoding = new HuffmanCoding();
huffmanCoding.EncodeFile(encodedFilePath);
```
This snippet demonstrates how to encode a text file using Huffman coding. First, an instance of the HuffmanCoding class is created. Then, the `EncodeFile` method is called with the `encodedFilePath` parameter, which represents the path to the text file to be encoded. This method reads the contents of the file, encodes the text using Huffman coding, and saves the encoded text to a new file with a ".hfc" extension.

### Encode Text:
```csharp
var huffmanCoding = new HuffmanCoding();
huffmanCoding.EncodeText(OriginalText);
```
Here, the code initializes Huffman coding by creating an instance of the HuffmanCoding class. Then, the `EncodeText` method is invoked with `OriginalText` as the parameter, representing the plain text to be encoded. This method encodes the provided text using Huffman coding and returns the encoded text.

### Decode File:
```csharp
var huffmanCoding = new HuffmanCoding();
huffmanCoding.DecodeFile(encodedFilePath);
```
In this snippet, Huffman coding is utilized to decode a text file that has been previously encoded. Similar to the encoding process, an instance of the HuffmanCoding class is created. Then, the `DecodeFile` method is called with `encodedFilePath` as the parameter, representing the path to the encoded file. This method reads the contents of the encoded file, decodes the text using Huffman coding, and returns the decoded text.

### Decode Text:
```csharp
var huffmanCoding = new HuffmanCoding();
huffmanCoding.DecodeText(encodedText);
```
Here, Huffman coding is employed to decode previously encoded text. First, an instance of the HuffmanCoding class is instantiated. Then, the `DecodeText` method is invoked with `encodedText` as the parameter, representing the text that has been encoded using Huffman coding. This method decodes the provided encoded text and returns the decoded plain text.

## Supported File Types

- Text files (.txt)
- JSON files (.json)
- YAML files (.yaml, .yml)
- XML files (.xml)
- CSV files (.csv)
- HTML files (.html)
- CSS files (.css)

### Authors

- Keanu Koelewijn
- Stefan Jesenko
- Salma Tanner

### License

This project is licensed under the Beerware License - see the [LICENSE.md](LICENSE) file for details.

These explanations provide a clear understanding of each code snippet's purpose and how it contributes to utilizing Huffman coding functionalities provided by the library.
