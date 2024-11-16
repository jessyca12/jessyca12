using System;
using System.Collections.Generic;

// Define a classe Produto para representar um produto eletrônico
class Produto
{
    public string Nome { get; set; }         // Nome do produto
    public decimal Preco { get; set; }       // Preço do produto
    public string Marca { get; set; }        // Marca do produto
    public string Categoria { get; set; }    // Categoria do produto (ex: Smartphone, Notebook)
    public int Quantidade { get; set; }      // Quantidade em estoque

    // Construtor da classe Produto, inicializando com nome, preço, marca e categoria
    public Produto(string nome, decimal preco, string marca, string categoria)
    {
        Nome = nome;
        Preco = preco;
        Marca = marca;
        Categoria = categoria;
        Quantidade = 0; // Inicializa o estoque como zero
    }

    // Método ToString para exibir informações do produto
    public override string ToString()
    {
        return $"{Nome} ({Marca}, {Categoria}) - R$ {Preco} - {Quantidade} em estoque";
    }
}

class Program
{
    // Lista de produtos para armazenar o estoque
    static List<Produto> produtos = new List<Produto>();

    static void Main(string[] args)
    {
        int opcao;
        do
        {
            // Exibe o menu principal
            Console.WriteLine("\n--- CONTROLE DE ESTOQUE - ELETRÔNICOS ---");
            Console.WriteLine("[1] Novo Produto");
            Console.WriteLine("[2] Listar Produtos");
            Console.WriteLine("[3] Remover Produto");
            Console.WriteLine("[4] Entrada Estoque");
            Console.WriteLine("[5] Saída Estoque");
            Console.WriteLine("[0] Sair");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine());

            // Executa a opção escolhida
            switch (opcao)
            {
                case 1:
                    AdicionarProduto(); // Chama o método para adicionar um novo produto
                    break;
                case 2:
                    ListarProdutos(); // Chama o método para listar todos os produtos
                    break;
                case 3:
                    RemoverProduto(); // Chama o método para remover um produto
                    break;
                case 4:
                    EntradaEstoque(); // Chama o método para adicionar quantidade no estoque
                    break;
                case 5:
                    SaidaEstoque(); // Chama o método para remover quantidade do estoque
                    break;
                case 0:
                    Console.WriteLine("Saindo... Obrigado por usar o Controle de Estoque de Eletrônicos!");
                    break;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        } while (opcao != 0); // Continua no loop até que a opção de sair seja selecionada
    }

    // Método para adicionar um novo produto
    static void AdicionarProduto()
    {
        Console.Write("Informe o nome do Produto: ");
        string nome = Console.ReadLine();

        Console.Write("Informe o preço: ");
        decimal preco = decimal.Parse(Console.ReadLine());

        Console.Write("Informe a marca: ");
        string marca = Console.ReadLine();

        Console.Write("Informe a categoria (ex: Smartphone, Notebook, Televisão): ");
        string categoria = Console.ReadLine();

        // Adiciona o novo produto à lista de produtos
        produtos.Add(new Produto(nome, preco, marca, categoria));
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    // Método para listar todos os produtos
    static void ListarProdutos()
    {
        Console.WriteLine("\n--- Lista de Produtos ---");
        if (produtos.Count == 0) // Verifica se a lista está vazia
        {
            Console.WriteLine("Nenhum produto cadastrado.");
        }
        else
        {
            // Exibe cada produto com seu índice
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {produtos[i]}");
            }
        }
    }

    // Método para remover um produto da lista
    static void RemoverProduto()
    {
        ListarProdutos(); // Lista os produtos para que o usuário possa escolher
        Console.Write("\nInforme a posição do produto a ser removido: ");
        int posicao = int.Parse(Console.ReadLine()) - 1;

        // Verifica se a posição é válida e remove o produto
        if (posicao >= 0 && posicao < produtos.Count)
        {
            produtos.RemoveAt(posicao);
            Console.WriteLine("Produto removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Posição inválida.");
        }
    }

    // Método para registrar entrada de estoque de um produto
    static void EntradaEstoque()
    {
        ListarProdutos(); // Lista os produtos para escolha
        Console.Write("\nInforme a posição do produto: ");
        int posicao = int.Parse(Console.ReadLine()) - 1;

        // Verifica se a posição é válida
        if (posicao >= 0 && posicao < produtos.Count)
        {
            Console.Write("Informe a quantidade de Entrada: ");
            int quantidade = int.Parse(Console.ReadLine());
            produtos[posicao].Quantidade += quantidade; // Adiciona ao estoque
            Console.WriteLine("Estoque atualizado!");
        }
        else
        {
            Console.WriteLine("Posição inválida.");
        }
    }

    // Método para registrar saída de estoque de um produto
    static void SaidaEstoque()
    {
        ListarProdutos(); // Lista os produtos para escolha
        Console.Write("\nInforme a posição do produto: ");
        int posicao = int.Parse(Console.ReadLine()) - 1;

        // Verifica se a posição é válida
        if (posicao >= 0 && posicao < produtos.Count)
        {
            Console.Write("Informe a quantidade de Saída: ");
            int quantidade = int.Parse(Console.ReadLine());
            
            // Verifica se há quantidade suficiente no estoque
            if (produtos[posicao].Quantidade >= quantidade)
            {
                produtos[posicao].Quantidade -= quantidade; // Subtrai do estoque
                Console.WriteLine("Estoque atualizado!");
            }
            else
            {
                Console.WriteLine("Quantidade insuficiente no estoque.");
            }
        }
        else
        {
            Console.WriteLine("Posição inválida.");
        }
    }
}




