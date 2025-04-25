using System.Text;
using sysvendas2.Context;
using sysvendas2.Models;

namespace sysvendas2.Telas;

static class TelaCadastroPedido
{
    public static void Show()
    {
        Console.Clear(); // Limpa a tela do console
        Console.OutputEncoding = Encoding.UTF8; // Pra mostrar caracteres especiais certinho
        ExibeTitulo(); // Mostra o título "Cadastro de Pedido"

        Console.WriteLine("\nDigite o ID do pedido:");
        int.TryParse(Console.ReadLine(), out int idPedido); // Pede o ID do pedido

        Console.WriteLine("\nDigite o ID do cliente:");
        int.TryParse(Console.ReadLine(), out int idCliente); // Pede o ID do cliente

        // *** Buscando o Cliente ***
        Cliente cliente = DBContext.RepositorioClientes.ObterClienteId(idCliente); // Busca o cliente no banco de dados (ou lista, etc.)
        if (cliente == null)
        {
            Console.WriteLine($"\nCliente com ID {idCliente} não encontrado!"); // Se não achar o cliente...
            Console.WriteLine("Pressione qualquer tecla para voltar ao menu principal...");
            Console.ReadKey();
            TelaPrincipal.Show(); // ...volta pro menu principal
            return;
        }

        DateTime dataPedido = DateTime.Now; // Pega a data de agora
        string statusPedido = "Em Aberto";  // Status padrão do pedido
        
        // APENAS COLETOU DADOS DO PEDIDO.

        Pedido pedido = new Pedido(idPedido, dataPedido, cliente, statusPedido); // Cria o objeto Pedido
        pedido.Items = new List<ItemPedido>(); // Inicializa a lista de itens do pedido

        bool adicionarMaisItens = true;
        while (adicionarMaisItens) // Loop pra adicionar vários itens
        {
            AdicionarItemAoPedido(pedido); // Adiciona um item ao pedido
            Console.Write("\nDeseja adicionar mais itens ao pedido? (s/n): ");
            adicionarMaisItens = Console.ReadLine().ToLower() == "s"; // Pergunta se quer adicionar mais
        }

        // *** Calculando o Total ***
        pedido.Total = pedido.Items.Sum(item => item.SubTotal); // Calcula o total do pedido somando os subtotais dos itens

        // *** Salvando o Pedido ***
        DBContext.RepositorioPedidos.Adicionar(pedido); // Salva o pedido no banco de dados (ou lista, etc.)

        Console.WriteLine("\nPedido cadastrado com sucesso!");
        ExibeResumoPedido(pedido); // Mostra um resumo do pedido

        Console.WriteLine("\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        TelaPrincipal.Show(); // Volta pro menu principal
    }

    private static void ExibeTitulo()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("========= 🛒 CADASTRO DE PEDIDO 🛒 =========");
        Console.WriteLine("=======================================");
    }

    private static void AdicionarItemAoPedido(Pedido pedido)
    {
        Console.WriteLine("\n--- Adicionar Item ao Pedido ---");

        Console.Write("Digite o SKU do produto: ");
        string sku = Console.ReadLine(); // Pede o SKU do produto

        // *** Buscando o Produto ***
        Produto produto = DBContext.RepositorioProdutos.ObterProduto(sku); // Busca o produto pelo SKU
        if (produto == null)
        {
            Console.WriteLine($"\nProduto com SKU {sku} não encontrado!");
            return; // Se não achar, sai da função (você pode querer dar outras opções aqui)
        }

        Console.Write("Digite a quantidade: ");
        int.TryParse(Console.ReadLine(), out int quantidade); // Pede a quantidade

        Console.Write("Digite o desconto (%): ");
        int.TryParse(Console.ReadLine(), out int desconto); // Pede o desconto

        ItemPedido item = new ItemPedido // Cria o objeto ItemPedido
        {
            Produto = produto,
            Quantidade = quantidade,
            Desconto = desconto,
            Preco = produto.PrecoUnit,
            SubTotal = (produto.PrecoUnit * quantidade) * (1 - desconto / 100.0) // Calcula o subtotal
        };

        pedido.Items.Add(item); // Adiciona o item à lista de itens do pedido
    }

    private static void ExibeResumoPedido(Pedido pedido)
    {
        Console.WriteLine("\n--- Resumo do Pedido ---");
        Console.WriteLine($"ID: {pedido.IdPedido}");
        Console.WriteLine($"Data: {pedido.Data}");
        Console.WriteLine($"Cliente: {pedido.Cliente.Nome} (ID: {pedido.Cliente.IdCliente})");
        Console.WriteLine($"Status: {pedido.Status}");

        Console.WriteLine("\n--- Itens do Pedido ---");
        foreach (var item in pedido.Items) // Mostra cada item do pedido
        {
            Console.WriteLine($"- {item.Produto.Nome} (SKU: {item.Produto.Sku})");
            Console.WriteLine($"  Quantidade: {item.Quantidade}, Preço Unitário: {item.Preco}, Desconto: {item.Desconto}%, Subtotal: {item.SubTotal}");
        }

        Console.WriteLine($"\nTotal do Pedido: {pedido.Total}"); // Mostra o total do pedido
    }
}