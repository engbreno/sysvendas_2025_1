namespace sysvendas2.Models;

public class ItemPedido
{
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public int Desconto { get; set; }
    public double Preco { get; set; }
    public double SubTotal { get; set; }
}