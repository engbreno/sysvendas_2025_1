using System.Text;

namespace sysvendas2.Telas;

static class TelaListaClientes
{
    
    static TelaListaClientes()
    {
        
    }

    public static void Show()
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;
        ExibeTitulo();
        foreach (var cliente in TelaCadastroCliente.clientes)
        {
            Console.WriteLine($"{cliente.IdCliente}: {cliente.Nome} - {cliente.Email}");
        }
       
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();
        TelaPrincipal.Show();
    }

    private static void ExibeTitulo()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("======= 🧑‍🦳 LISTA DE CLIENTES 🧑‍🦳========");
        Console.WriteLine("=======================================");
    }
}

/*
        cliente = new List<Cliente>
        {
            new Opcao(1," ❤️ Cadastrar cliente"),
            new Opcao(2, "Listar clientes"),
            new Opcao(3, "Sair")
        };
*/