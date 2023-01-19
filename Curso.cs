using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    [System.Serializable]
    public class Curso : Produto, IEstoque
    {
        public string autor;
        private int vagas;

        public Curso(string nome, float preco, string autor)
        {
            this.autor = autor;
            this.nome = nome;
            this.preco = preco;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar de vagas no curso: {nome}");
            Console.WriteLine("Adicione a quantidade de vagas disponiveis:");
            int entrada = int.Parse(Console.ReadLine());

            vagas += entrada;

            Console.WriteLine("Vaga(s) registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Consumir de vagas no curso: {nome}");
            Console.WriteLine("Adicione a quantidade de vagas consumidas:");
            int entrada = int.Parse(Console.ReadLine());

            if (vagas > 0)
            {
                vagas -= entrada;
                Console.WriteLine("Vaga(s) registrada");
            }
            else
            {
                Console.WriteLine("Vaga(s) indisponiveis");
            }

            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"=== {this.nome} ===");
            Console.WriteLine($"Preco: {this.preco}");
            Console.WriteLine($"Livro de {this.autor}");
            Console.WriteLine($"Vagas Disponíveis: {this.vagas}");
        }
    }
}