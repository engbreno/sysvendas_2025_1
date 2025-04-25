namespace sysvendas2.Repository;
using System.Text.Json;
using sysvendas2.Interfaces;
using sysvendas2.Models;

public class RepositorioPedidoJson : IRepositorioPedido
{
    private readonly string _caminhoArquivo;
    private List<Pedido> _pedidos;

    public RepositorioPedidoJson(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
        _pedidos = CarregarDoArquivo();
    }

    public void Adicionar(Pedido pedido)
    {
        _pedidos.Add(pedido);
        SalvarNoArquivo();
    }

    public List<Pedido> ObterTodos()
    {
        return new List<Pedido>(_pedidos);
    }

    private List<Pedido> CarregarDoArquivo()
    {
        if (!File.Exists(_caminhoArquivo))
            return new List<Pedido>();

        var json = File.ReadAllText(_caminhoArquivo);
        return JsonSerializer.Deserialize<List<Pedido>>(json) ?? new List<Pedido>();
    }

    private void SalvarNoArquivo()
    {
        var json = JsonSerializer.Serialize(_pedidos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_caminhoArquivo, json);
    }
}