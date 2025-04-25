using System.Text.Json;
using sysvendas2.Context;
using sysvendas2.Repository;
using sysvendas2.Telas;
using sysvendas2.Models;

DBContext.RepositorioClientes = new RepositorioClienteJson("clientes.json");
DBContext.RepositorioProdutos = new RepositorioProdutoJson("produtos.json");
DBContext.RepositorioPedidos = new RepositorioPedidoJson("pedidos.json");

TelaPrincipal.Show();

/*
Cliente cliente1 = new Cliente(1,"Breno","breno@gmail.com","12345678");
Produto produto1 = new Produto("BR123","Tenis Rider",100.30,"Calçado");
Produto produto2 = new Produto("BR333","Calça Renner",100.30,"Starlink");

Pedido pedido1 = new Pedido(1, DateTime.Now, cliente1, "Aberto" );
ItemPedido item1 = new ItemPedido();
item1.Produto = produto1;
item1.Quantidade = 5;
item1.Preco = produto1.PrecoUnit * (1 - item1.Desconto);
item1.SubTotal = item1.Quantidade * item1.Preco;

ItemPedido item2 = new ItemPedido();
item2.Produto = produto2;
item2.Quantidade = 3;
item2.Preco = produto2.PrecoUnit * (1 - item2.Desconto);
item2.SubTotal = item2.Quantidade * item2.Preco;

pedido1.Items = new List<ItemPedido>();
pedido1.Items.Add(item1);
pedido1.Items.Add(item2);

var json = JsonSerializer.Serialize(pedido1, new JsonSerializerOptions { WriteIndented = true });
//Console.WriteLine(json);

Console.WriteLine(pedido1.Cliente.Nome);
Console.WriteLine(pedido1.Items[0].Produto.Nome);
*/