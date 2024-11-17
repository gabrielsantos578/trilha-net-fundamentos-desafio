using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n");

// Instancia a classe Estacionamento
Estacionamento es = new();

bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Ocupar vaga");
    Console.WriteLine("2 - Liberar vaga");
    Console.WriteLine("3 - Listar vagas");
    Console.WriteLine("4 - Listar veículos");
    Console.WriteLine("5 - Listar histórico de usos");
    Console.WriteLine("6 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            es.OcuparVaga();
            break;

        case "2":
            es.DesocuparVaga();
            break;

        case "3":
            es.ListarVagas();
            break;

        case "4":
            es.ListarVeiculos();
            break;

        case "5":
            es.ListarHistoricoUso();
            break;

        case "6":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou");
