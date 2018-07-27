using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPT9
{
    partial class Program
    {
        static void EscreveDocumentoCompactado()
        {
            using (var arquivo = File.OpenWrite("c:/temp/documentoCompactado.txt"))
            using (var compressor = new DeflateStream(arquivo, CompressionMode.Compress))
            using (var escritor = new StreamWriter(compressor))
            {
                escritor.Write("Lorem ipsum dolor sit amet, consectetur adipiscing elit,");
                escritor.Write("sed do eiusmod tempor incididunt ut labore et dolore magna ");
                escritor.Write("aliqua. Ut enim ad minim veniam, quis nostrud exercitation ");
                escritor.Write("ullamco laboris nisi ut aliquip ex ea commodo consequat.Duis ");
                escritor.Write("aute irure dolor in reprehenderit in voluptate velit esse cillum ");
                escritor.Write("dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat ");
                escritor.Write("non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
            }
        }

        static void LeDocumentoCompactado()
        {
            using (var arquivo = File.OpenRead("c:/temp/documentoCompactado.txt"))
            using (var decompressor = new DeflateStream(arquivo, CompressionMode.Decompress))
            using (var leitor = new StreamReader(decompressor))
            {
                while(!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    Console.WriteLine(linha);
                }
            }
        }
    }
}
