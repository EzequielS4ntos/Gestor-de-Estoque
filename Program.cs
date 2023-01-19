using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using GestorDeEstoque;

namespace Program
{
    internal class Program
    {
        static List<IEstoque> produtos = new List<IEstoque>();
        private static void Main(string[] args)
        {
            Carregar();
            Console.Clear();

            bool escolheuSair = false;
            while (!escolheuSair)
            {
                Console.Clear();

                Console.WriteLine("=== Gestor de Estoque === ");
                Console.WriteLine("1 - Listar\n2 - Adicionar\n3 - Remover\n4 - Entrada\n5 - Saida\n6 - Sair");
                string opConsole = Console.ReadLine();
                int opInt = int.Parse(opConsole);

                if (opInt > 0 && opInt < 7)
                {
                    if (opInt == 1) /* Listar */
                    {
                        Listar();
                        Console.WriteLine("\nAperte ENTER para continuar...");
                        Console.ReadLine();
                    }
                    if (opInt == 2) /* Adicionar */
                    {
                        Cadastro();
                    }
                    if (opInt == 3) /* Remover */
                    {
                        Remover();
                    }
                    if (opInt == 4) /* Entrada */
                    {
                        Entrada();
                    }
                    if (opInt == 5) /* Saida */
                    {
                        Saida();
                    }
                    if (opInt == 6) /* Sair */
                    {
                        escolheuSair = true;
                    }
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
            }

            Console.Clear();
        }

        static void Listar()
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Produtos ===");
            int i = 0;
            foreach (IEstoque produto in produtos)
            {
                produto.Exibir();
                Console.WriteLine($"ID: {i}");
                Console.WriteLine("\n================================");
                i++;
            }
        }

        static void Remover()
        {
            bool pararExclusão = false;
            while (!pararExclusão)
            {
                Listar();
                Console.WriteLine("Digite o ID do elemento que deseja remover ou digite 'sair' para sair:");
                string opcao = Console.ReadLine();

                if (opcao == "sair")
                {
                    pararExclusão = true;
                }
                else
                {
                    int ID = int.Parse(opcao);
                    if (ID >= 0 && ID < produtos.Count)
                    {
                        produtos.RemoveAt(ID);
                        Salvar(); 
                    }
                    
                }
            }
            Listar();
        }

        static void Cadastro()
        {
            Console.Clear();
            Console.WriteLine("\n=== Cadastro de Produtos ===\n");
            Console.WriteLine("1 - Curso\n2 - Ebook\n3 - Produto Fisico");

            string opStr = Console.ReadLine();
            int opInt = int.Parse(opStr);

            if (opInt == 1)
            {
                CadastrarCurso();
            }
            if (opInt == 2)
            {
                CadastroEbook();
            }
            if (opInt == 3)
            {
                CadastroPFisico();
            }

            Console.Clear();
        }

        static void Entrada()
        {
            Listar();
            Console.WriteLine("Digite o ID do elemento que deseja Adicionar entrada:");
            int ID = int.Parse(Console.ReadLine());

            if (ID >= 0 && ID < produtos.Count)
            {
                produtos[ID].AdicionarEntrada();
                Salvar();
            }
        }

        static void Saida()
        {
            Listar();
            Console.WriteLine("Digite o ID do elemento que deseja registrar baixa:");
            int ID = int.Parse(Console.ReadLine());

            if (ID >= 0 && ID < produtos.Count)
            {
                produtos[ID].AdicionarSaida();
                Salvar();
            }
        }

        static void CadastroPFisico()
        {
            Console.Clear();
            Console.WriteLine("=== Cadastrando de Produtos Físicos ===");
            Console.WriteLine("Nome: "); string nome = Console.ReadLine();
            Console.WriteLine("Preco: "); float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Frete: "); float frete = float.Parse(Console.ReadLine());

            ProdutoFisico pf = new ProdutoFisico(nome, preco, frete);
            produtos.Add(pf);
            Salvar();

            Console.WriteLine("Produto Cadastrado com sucesso, aperte ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        static void CadastroEbook()
        {
            Console.Clear();
            Console.WriteLine("=== Cadastrando de Ebooks ===");
            Console.WriteLine("Nome: "); string nome = Console.ReadLine();
            Console.WriteLine("Preco: "); float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: "); string autor = Console.ReadLine();

            Ebook eb = new Ebook(nome, preco, autor);
            produtos.Add(eb);
            Salvar();

            Console.WriteLine("Produto Cadastrado com sucesso, aperte ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        static void CadastrarCurso()
        {
            Console.Clear();
            Console.WriteLine("=== Cadastrando de Cursos ===");
            Console.WriteLine("Nome: "); string nome = Console.ReadLine();
            Console.WriteLine("Preco: "); float preco = float.Parse(Console.ReadLine());
            Console.WriteLine("Autor: "); string autor = Console.ReadLine();

            Curso cs = new Curso(nome, preco, autor);
            produtos.Add(cs);
            Salvar();

            Console.WriteLine("Produto Cadastrado com sucesso, aperte ENTER para continuar...");
            Console.ReadLine();
            Console.Clear();
        }

        static void Salvar()
        {
            FileStream stream = new FileStream("Produtos/produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            encoder.Serialize(stream, produtos);

            stream.Close();
        }

        static void Carregar()
        {
            FileStream stream = new FileStream("Produtos/produtos.dat", FileMode.OpenOrCreate);
            BinaryFormatter encoder = new BinaryFormatter();

            try
            {
                produtos = (List<IEstoque>)encoder.Deserialize(stream);

                if (produtos == null)
                {
                    produtos = new List<IEstoque>();
                }
            }
            catch
            {
                produtos = new List<IEstoque>();
            }

            stream.Close();
        }
    }
}