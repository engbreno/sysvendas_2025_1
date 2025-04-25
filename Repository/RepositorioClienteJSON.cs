namespace sysvendas2.Repository;
using System.Text.Json;
using sysvendas2.Interfaces;
using sysvendas2.Models;

public class RepositorioClienteJson : IRepositorioCliente
{
    private readonly string _caminhoArquivo;
    private List<Cliente> _clientes;

    public RepositorioClienteJson(string caminhoArquivo)
    {
        _caminhoArquivo = caminhoArquivo;
        _clientes = CarregarDoArquivo();
    }

    public void Adicionar(Cliente cliente)
    {
        _clientes.Add(cliente);
        SalvarNoArquivo();
    }

    public List<Cliente> ObterTodos()
    {
        return new List<Cliente>(_clientes);
    }
    
    public Cliente? ObterClienteId(int idcliente)
    {
        return _clientes.FirstOrDefault(c => c.IdCliente == idcliente);
    }

    public Cliente? ObterClienteNome(string nomecliente)
    {
        var resultado = _clientes
            .Where(c => c.Nome.StartsWith(nomecliente))
            .OrderBy(c => c.Nome);
        return resultado.FirstOrDefault();
    }

    private List<Cliente> CarregarDoArquivo()
    {
        if (!File.Exists(_caminhoArquivo))
            return new List<Cliente>();

        var json = File.ReadAllText(_caminhoArquivo);
        return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
    }

    private void SalvarNoArquivo()
    {
        var json = JsonSerializer.Serialize(_clientes, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_caminhoArquivo, json);
    }
}