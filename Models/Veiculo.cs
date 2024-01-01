using Estacionamento_DIO.Repository;

namespace Estacionamento_DIO.Models
{
    public class Veiculo
    {
        public DateTime HorarioEntrada { get; private set; }
        public string Placa { get; private set; }
        private readonly EstacionamentoRepository _estacionamentoRepository;

        public Veiculo(EstacionamentoRepository estacionamentoRepository)
        {
            _estacionamentoRepository = estacionamentoRepository;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            Placa = Console.ReadLine() ?? "";
            HorarioEntrada = DateTime.Now;
            _estacionamentoRepository.AdicionarVeiculo(this);
            _estacionamentoRepository.Confirmar();
            Console.WriteLine($"O veículo {Placa} foi estacionado com sucesso.");
        }
    }
}