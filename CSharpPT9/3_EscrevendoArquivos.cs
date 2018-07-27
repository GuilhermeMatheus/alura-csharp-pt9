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
        static void EscreverArquivo()
        {
            using (var arquivo = new FileStream("c:/temp/bytebank_contas2.txt", FileMode.OpenOrCreate))
            using (var escritor = new StreamWriter(arquivo))
            {
                escritor.WriteLine("ContaCorrente ag. 340, nº 45345");
                escritor.WriteLine("ContaCorrente ag. 341, nº 32854");
                escritor.WriteLine("ContaCorrente ag. 342, nº 37852");

                // Testando o flush
                for (int i = 0; i < 100; i++) 
                {
                    Console.WriteLine("Dê enter para escrever mais uma linha");
                    Console.ReadLine();
                    escritor.WriteLine("ajegsdjhfgsdjhfgsdjhfgsdjhgsdjkfgsdfjhgsdfjsdgfhsdgfjhsdgfjhsdgf");

                    escritor.Flush();
                    arquivo.Flush(true);
                }
            }
        }
    }
}
