using System.Globalization;
using Estacionamento_DIO.DTO;
using Estacionamento_DIO.Repository;

namespace Estacionamento_DIO.Models
{
    public class Estacionamento
    {
        private decimal precoInicial { get; set; }
        private decimal precoPorHora { get; set; }
        private readonly EstacionamentoRepository estacionamentoRepository;
        public Estacionamento(decimal precoInicial, decimal precoPorHora, EstacionamentoRepository estacionamentoRepository)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
            this.estacionamentoRepository = estacionamentoRepository;
        }

        public void AdicionarVeiculo()
        {
            Veiculo veiculo = new Veiculo(estacionamentoRepository);
            veiculo.AdicionarVeiculo();
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine() ?? "";
            if(estacionamentoRepository.ListarVeiculos().Any(x => x.Placa.ToUpper().Trim() == placa.ToUpper().Trim()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");
                string quantidadeHoras = Console.ReadLine() ?? "1";
                int quantidadeHorasEstacionado = int.Parse(quantidadeHoras == String.Empty ? "1": quantidadeHoras);
                decimal valorTotal = precoInicial + precoPorHora * quantidadeHorasEstacionado;
                estacionamentoRepository.RemoverVeiculo(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: {string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valorTotal)}");
                estacionamentoRepository.Confirmar();
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente.");
            }
        }

        
        public void ListarVeiculos()
        {
            List<VeiculoDto> veiculos = estacionamentoRepository.ListarVeiculos();
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach(x => 
                {
                    Console.WriteLine(x.Placa);
                });
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}