namespace sysvendas2.Telas;

public class Opcao
{
    public int Id { get; set; }
    public string Descricao { get; set; }

    public Opcao(int id, string desc)
    {
        Id = id;
        Descricao = desc;
    }
}