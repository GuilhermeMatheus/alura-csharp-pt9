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
        static void UsarFileStreamComStreamReader()
        {
            using (var arquivo = new FileStream("c:/temp/bytebank_contas.txt", FileMode.Open))
            using (var leitor = new StreamReader(arquivo, Encoding.Unicode))
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
