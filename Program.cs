using sysvendas2.Context;
using sysvendas2.Repository;
using sysvendas2.Telas;

DBContext.RepositorioClientes = new RepositorioClienteJson("clientes.json");
DBContext.RepositorioProdutos = new RepositorioProdutoJson("produtos.json");

TelaPrincipal.Show();