namespace sysvendas2.Models;

public class Pedido
{
    public Pedido(int idpedido, DateTime data, Cliente cliente, string status)
    {
        IdPedido = idpedido;
        Data = data;
        Cliente = cliente;
        Status = status;
    }
    
    public int IdPedido { get; set; }
    public DateTime Data { get; set; }
    public Cliente Cliente { get; set; }
    public string Status { get; set; }
    public List<Produto> Produtos { get; set; }
}