using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestorDeEstoque
{
    [System.Serializable]
    public class Ebook : Produto, IEstoque
    {
        public string autor;
        private int vendas;

        public Ebook(string nome, float preco, string autor)
        {
            this.autor = autor;
            this.nome = nome;
            this.preco = preco;
        }

        public void AdicionarEntrada()
        {
            Console.WriteLine("Impossivel registrar entrada");
            Console.ReadLine();
        }

        public void AdicionarSaida()
        {
            Console.WriteLine($"Adicionar venda do EBook: {nome}");
            Console.WriteLine("Adicione a quantidade de vendas:");
            int entrada = int.Parse(Console.ReadLine());

            vendas += entrada;

            Console.WriteLine("Venda(s) registrada");
            Console.ReadLine();
        }

        public void Exibir()
        {
            Console.WriteLine($"=== {this.nome} ===");
            Console.WriteLine($"Preco: {this.preco}");
            Console.WriteLine($"Livro de {this.autor}");
            Console.WriteLine($"Vendas: {this.vendas}");
        }
    }
}