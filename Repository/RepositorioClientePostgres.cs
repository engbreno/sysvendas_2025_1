using sysvendas2.Interfaces;
using sysvendas2.Models;
using Dapper;
using Npgsql;

namespace sysvendas2.Repository;

public class RepositorioClientePostgres : IRepositorioCliente
{
    private readonly string _connStr;

    public RepositorioClientePostgres(string connStr)
    {
        _connStr = connStr;
    }
    
    public void CriarTabelas()
    {
        var sql = @"
        CREATE TABLE IF NOT EXISTS Clientes (
            IdCliente SERIAL PRIMARY KEY,
            Nome TEXT NOT NULL,
            Email TEXT NOT NULL,
            Telefone TEXT NOT NULL
        );";
        using var conn = new NpgsqlConnection(_connStr);
        conn.Execute(sql);
    }
    
    public async Task<Cliente?> Adicionar(Cliente cliente)
    {
        Console.WriteLine(" Chasdiuhasuidhsaudhuashdasdusa");
        var sql = "INSERT INTO Clientes (Nome, Email, Telefone) VALUES (@Nome, @Email, @Telefone) RETURNING *";
        using var conn = new NpgsqlConnection(_connStr);
        await conn.OpenAsync();
        using var cmd = new NpgsqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("Nome", cliente.Nome);
        cmd.Parameters.AddWithValue("Email", cliente.Email);
        cmd.Parameters.AddWithValue("Telefone", cliente.Telefone);
        using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            int id = reader.GetInt32(0);
            string nome = reader.GetString(1);
            string email = reader.GetString(2);
            string telefone = reader.GetString(3);
            var clienteReturn = new Cliente(id, nome, email,telefone);
            return clienteReturn;
        }

        return null;

    }

    public List<Cliente> ObterTodos()
    {
        var sql = "SELECT * FROM Clientes ORDER BY Nome";
        using var conn = new NpgsqlConnection(_connStr);
        return conn.Query<Cliente>(sql).ToList();
    }

    public Cliente? ObterClienteId(int idcliente)
    {
        throw new NotImplementedException();
    }

    public Cliente? ObterClienteNome(string nome)
    {
        var sql = "SELECT * FROM Clientes WHERE Nome ILIKE @Nome";
        using var conn = new NpgsqlConnection(_connStr);
        return conn.QueryFirstOrDefault<Cliente>(sql, new { Nome = $"%{nome}%" });
    }
}