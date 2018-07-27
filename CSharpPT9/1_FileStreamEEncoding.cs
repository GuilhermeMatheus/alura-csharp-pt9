using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPT9
{
    partial class Program
    {
        static void UsarFileStream()
        {
            var buffer = new byte[1024];
            var bytesLidos = -1;

            using (var arquivo = new FileStream("c:/temp/bytebank_contas.txt", FileMode.Open))
            {
                while (bytesLidos != 0)
                {
                    bytesLidos = arquivo.Read(buffer, 0, buffer.Length);
                    Console.WriteLine($"Bytes lidos: {bytesLidos}");
                    EscreverBytesNaTela(buffer, bytesLidos);
                }
            }
        }

        static void EscreverBytesNaTela(byte[] bytes, int contagemBytes)
        {
            //foreach (var _byte in bytes)
            //{
            //    Console.Write(_byte);
            //}

            //var encoding = Encoding.UTF8;
            var encoding = new UnicodeEncoding();
            var texto = encoding.GetString(bytes, 0, contagemBytes);
            Console.WriteLine(texto);
        }
    }
}
