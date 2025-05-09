namespace sysvendas2.Interfaces;
using sysvendas2.Models;

public interface IRepositorioCliente
{
    Task<Cliente?> Adicionar(Cliente cliente);
    List<Cliente> ObterTodos(); 
    Cliente? ObterClienteId(int idcliente);
    Cliente? ObterClienteNome(string nomecliente);

}