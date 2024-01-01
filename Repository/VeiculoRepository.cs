using System.Text.Json;
using Estacionamento_DIO.DTO;
using Estacionamento_DIO.Models;

namespace Estacionamento_DIO.Repository
{
    public class EstacionamentoRepository
    {
        private List<VeiculoDto> veiculos = new List<VeiculoDto>();

        public EstacionamentoRepository()
        {
            try
            {
                string jsonVeiculos = File.ReadAllText("ArquivoEstacionamento.json");
                veiculos = JsonSerializer.Deserialize<List<VeiculoDto>>(jsonVeiculos) ?? new List<VeiculoDto>();
            }
            catch(JsonException ex)
            {
                Console.WriteLine($"Falha ao ler o json {ex.Message}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Falha ao encontrar o arquivo ou diretório {ex.Message}");
                throw;
            }
        }

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            veiculos.Add(new VeiculoDto{ Placa = veiculo.Placa, HorarioEntrada = veiculo.HorarioEntrada });
        }

        public void RemoverVeiculo(string placa)
        {
            var veiculo = veiculos.FirstOrDefault(x => x.Placa.ToUpper().Trim() == placa.ToUpper().Trim());

            if(veiculo == null)
            {
                return;
            }
                 
            veiculos.Remove(veiculo);
        }

        public List<VeiculoDto> ListarVeiculos()
        {
            return veiculos;
        }

        public void Confirmar(){
            try
            {
                File.WriteAllText("ArquivoEstacionamento.json", JsonSerializer.Serialize(veiculos));
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Falha ao encontrar o arquivo ou diretório {ex.Message}");
                throw;
            }
        }
    }
}