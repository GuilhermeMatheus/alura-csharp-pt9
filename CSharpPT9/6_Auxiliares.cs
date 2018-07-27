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
        static void LerLinhas()
        {
            var linhas = File.ReadAllLines("c:/temp/bytebank_contas2.txt");

            foreach (var linha in linhas)
                Console.WriteLine(linha);
        }

        static void LerTudo()
        {
            var documentoCompleto = File.ReadAllText("c:/temp/bytebank_contas2.txt");
            Console.WriteLine(documentoCompleto);
        }
    }
}
