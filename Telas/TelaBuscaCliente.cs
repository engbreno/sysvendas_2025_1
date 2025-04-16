using System.Text;
using sysvendas2.Context;

namespace sysvendas2.Telas;

static class TelaBuscaCliente
{
    static TelaBuscaCliente()
    {
    }

    public static void Show()
    {
        Console.Clear();
        Console.OutputEncoding = Encoding.UTF8;
        ExibeTitulo();

        Console.Write("Digite o ID do cliente que deseja buscar: ");
        if (int.TryParse(Console.ReadLine(), out int idCliente))
        {
            var cliente = DBContext.RepositorioClientes?.ObterCliente(idCliente);

            if (cliente != null)
            {
                Console.WriteLine("\nCliente encontrado:");
                Console.WriteLine($"ID: {cliente.IdCliente}");
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"Email: {cliente.Email}");
            }
            else
            {
                Console.WriteLine("\n❌ Cliente não encontrado.");
            }
        }
        else
        {
            Console.WriteLine("\n❌ ID inválido. Digite um número inteiro.");
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
        TelaPrincipal.Show();
    }

    private static void ExibeTitulo()
    {
        Console.WriteLine("=======================================");
        Console.WriteLine("====== 🔎 BUSCA DE CLIENTE 🔍 ========");
        Console.WriteLine("=======================================");
    }
}