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
        static void EscreveDocumentoEmFormatoBinario()
        {
            using (var arquivo = File.OpenWrite("c:/temp/documentoBinario.txt"))
            using (var escritorBinario = new BinaryWriter(arquivo))
            {
                escritorBinario.Write(340);
                escritorBinario.Write(7563242);
                escritorBinario.Write("Conta corrente 7563242 ag. 340");
            }
        }

        static void LeDocumentoEmFormatoBinario()
        {
            using (var arquivo = File.OpenRead("c:/temp/documentoBinario.txt"))
            using (var leitorBinario = new BinaryReader(arquivo))
            {
                var agencia = leitorBinario.ReadInt32();
                var numero = leitorBinario.ReadInt32();
                var texto = leitorBinario.ReadString();

                Console.WriteLine($"{agencia}/{numero}");
                Console.WriteLine(texto);
            }
        }
    }
}
