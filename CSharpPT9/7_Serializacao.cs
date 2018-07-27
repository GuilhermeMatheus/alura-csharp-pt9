using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CSharpPT9
{
    partial class Program
    {
        static void EscreveContas()
        {
            var titular = new Cliente
            {
                Nome = "Luana",
                Profissao = "Desenvolvedora",
                DataNascimento = new DateTime(1989, 1, 15)
            };

            var contas = new []
            {
                new ContaCorrente(432, 545325) { Saldo = 100, Titular = titular },
                new ContaCorrente(322, 23442) { Saldo = 200, Titular = titular }
            };

            var serializador = new DataContractSerializer(typeof(ContaCorrente[]));

            //using (var arquivo = File.Create("c:/temp/contas.xml"))
            //using (var escritorXml = XmlWriter.Create(arquivo))
            //{
            //    serializador.WriteObject(escritorXml, contas);
            //}

            using (var streamNaMemoria = new MemoryStream())
            using(var escritorXml = XmlWriter.Create(streamNaMemoria))
            {
                serializador.WriteObject(escritorXml, contas);

                streamNaMemoria.Position = 0;
                var leitor = new StreamReader(streamNaMemoria);
                var conteudo = leitor.ReadToEnd();
                Console.WriteLine(conteudo);
            }
        }
        static void LeContas()
        {
            var serializador = new DataContractSerializer(typeof(ContaCorrente[]));

            using (var arquivo = File.OpenRead("c:/temp/contas.xml"))
            {
                var resultado = serializador.ReadObject(arquivo) as ContaCorrente[];

                foreach (var conta in resultado)
                {
                    Console.WriteLine($"{conta.Agencia}/{conta.Numero}");
                    Console.WriteLine($"{conta.Titular.Nome}");
                }
            }
        }

    }

    [DataContract(IsReference = true)]
    public class Cliente
    {
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Profissao { get; set; }
        [DataMember]
        public DateTime DataNascimento { get; set; }
    }

    [DataContract]
    public class ContaCorrente
    {
        [DataMember]
        public double Saldo { get; set; }

        [DataMember]
        public Cliente Titular { get; set; }

        [DataMember]
        public int Numero { get; private set; }

        [DataMember]
        public int Agencia { get; private set; }

        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
        }
    }
}
