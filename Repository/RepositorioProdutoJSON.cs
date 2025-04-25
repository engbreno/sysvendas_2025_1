namespace sysvendas2.Repository;
using System.Text.Json;
using sysvendas2.Interfaces;
using sysvendas2.Models;

public class RepositorioProdutoJson : IRepositorioProduto
{
    private readonly string _caminhoArquivo;
    private List<Produto> _produtos;

    public RepositorioProdutoJson(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
        _produtos = CarregarDoArquivo();
    }

    public void Adicionar(Produto produto)
    {
        _produtos.Add(produto);
        SalvarNoArquivo();
    }

    public List<Produto> ObterTodos()
    {
        return new List<Produto>(_produtos);
    }

    public Produto ObterProduto(string sku)
    {
        return _produtos.FirstOrDefault(p => p.Sku == sku);
    }

    private List<Produto> CarregarDoArquivo()
    {
        if (!File.Exists(_caminhoArquivo))
            return new List<Produto>();

        var json = File.ReadAllText(_caminhoArquivo);
        return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
    }

    private void SalvarNoArquivo()
    {
        var json = JsonSerializer.Serialize(_produtos, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_caminhoArquivo, json);
    }
}