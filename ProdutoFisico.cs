using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeEstoque
{[System.Serializable]
    public class ProdutoFisico : Produto, IEstoque
    {
        public float frete;
        private int estoque;

        public ProdutoFisico(string nome, float preco, float frete)
        {
            this.nome = nome;
            this.preco = preco;
            this.frete = frete;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine($"Adicionar em estoque do produto {nome}");
            Console.WriteLine("Adicione a quantidade de entrada:");
            int entrada = int.Parse(Console.ReadLine());

            estoque += entrada;

            Console.WriteLine("\nEntrada registrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar em estoque do produto {nome}");
            Console.WriteLine("Adicione a quantidade de entrada:");
            int entrada = int.Parse(Console.ReadLine());

            if (estoque > 0)
            {
                estoque -= entrada;
                Console.WriteLine("Saida Registrada registrada");
            }
            else
            {
                Console.WriteLine("Indisponivel em estoque");
            }

            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"=== {this.nome} ===");
            Console.WriteLine($"Preco: {this.preco}");
            Console.WriteLine($"Frete: {this.frete}");
            Console.WriteLine($"Em estoque: {this.estoque}");
        }
    }
}