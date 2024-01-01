using Estacionamento_DIO.Models;
using Estacionamento_DIO.Repository;

Console.OutputEncoding = System.Text.Encoding.UTF8;
EstacionamentoRepository estacionamentoRepository = new EstacionamentoRepository();

Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
string precoEntrada = Console.ReadLine() ?? "5";
decimal precoInicial = Convert.ToDecimal(precoEntrada == String.Empty ? "5" : precoEntrada);

Console.WriteLine("Agora digite o preço por hora:");
string precoHora = Console.ReadLine() ?? "4";
decimal precoPorHora = Convert.ToDecimal(precoHora == String.Empty ? "4" : precoHora);

// Instancia a classe Estacionamento, já com os valores obtidos anteriormente
Estacionamento estacionamento = new Estacionamento(precoInicial, precoPorHora, estacionamentoRepository);

string opcao = string.Empty;
bool exibirMenu = true;

// Realiza o loop do menu
while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Digite a sua opção:");
    Console.WriteLine("1 - Cadastrar veículo");
    Console.WriteLine("2 - Remover veículo");
    Console.WriteLine("3 - Listar veículos");
    Console.WriteLine("4 - Encerrar");

    switch (Console.ReadLine())
    {
        case "1":
            estacionamento.AdicionarVeiculo();
            break;

        case "2":
            estacionamento.RemoverVeiculo();
            break;

        case "3":
            estacionamento.ListarVeiculos();
            break;

        case "4":
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida");
            break;
    }

    Console.WriteLine("Pressione uma tecla para continuar.");
    Console.ReadLine();
}

Console.WriteLine("O programa se encerrou.");