namespace sysvendas2.Telas;
class TelaPrincipal
{
    private List<Opcao> opcoes;
    public TelaPrincipal()
    {
        opcoes = new List<Opcao>
        {
            new Opcao(1," ❤️ Cadastrar cliente"),
            new Opcao(2, "Listar clientes"),
            new Opcao(3, "Sair")
        };

        Opcao newOpt = new Opcao(4, "haudhaushd");
        newOpt.Descricao = "Oi tudo bem";
        
    }
    public void Show()
    {
        ExibeTitulo();
        foreach (var opt in opcoes)
        {
            Console.WriteLine($"{opt.Id} - {opt.Descricao}");
        }
    }
    private void ExibeTitulo()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("=========== 🔥 SYSVENDAS 2 🔥==========");
        Console.WriteLine("=======================================");
    }
}