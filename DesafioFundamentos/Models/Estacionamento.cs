using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private readonly List<Vaga> Vagas;
        private readonly List<Veiculo> Veiculos;

        public Estacionamento()
        {
            Vagas = GerarVagasIniciais();
            Veiculos = new List<Veiculo>();
        }

        private static List<Vaga> GerarVagasIniciais()
        {
            var vagas = new List<Vaga>();
            for (int i = 1; i <= 8; i++)
            {
                string numeracao = $"V{i:D2}";
                decimal precoInicial = 5.00m;
                decimal precoHora = 2.00m;
                vagas.Add(new Vaga(numeracao, precoInicial, precoHora));
            }
            return vagas;
        }

        public void OcuparVaga()
        {
            while (true)
            {
                Console.WriteLine("Informe a numeração da vaga onde irá estacionar:");
                string numeracao = Console.ReadLine();

                if (string.IsNullOrEmpty(numeracao))
                {
                    Console.WriteLine("A numeração da vaga é obrigatória!");
                    continue;
                }

                var vaga = Vagas.FirstOrDefault(v => v.Numeracao == numeracao);
                if (vaga == null)
                {
                    Console.WriteLine("A vaga informada não existe!");
                    continue;
                }

                if (vaga.Ocupada)
                {
                    Console.WriteLine("A vaga já está ocupada!");
                    continue;
                }

                Console.WriteLine("Informe a placa do veículo:");
                string placa = Console.ReadLine();

                if (string.IsNullOrEmpty(placa))
                {
                    Console.WriteLine("A placa do veículo é obrigatória!");
                    continue;
                }

                var veiculo = Veiculos.FirstOrDefault(v => v.Placa.ToUpper() == placa.ToUpper());
                if (veiculo != null && veiculo.Estacionado)
                {
                    Console.WriteLine("O veículo informado já está estacionado!");
                    continue;
                }

                if (veiculo == null)
                {
                    veiculo = new Veiculo(placa.ToUpper());
                    Veiculos.Add(veiculo);
                }

                veiculo.Estacionou();
                var uso = new Uso(placa);
                vaga.AdicionarUso(uso);

                Console.WriteLine($"Veículo {placa.ToUpper()} estacionado na vaga {numeracao}.");
                break;
            }
        }

        public void DesocuparVaga()
        {
            while (true)
            {
                Console.WriteLine("Informe a numeração da vaga para desocupar:");
                string numeracao = Console.ReadLine();

                if (string.IsNullOrEmpty(numeracao))
                {
                    Console.WriteLine("A numeração da vaga é obrigatória!");
                    continue;
                }

                var vaga = Vagas.FirstOrDefault(v => v.Numeracao == numeracao);
                if (vaga == null)
                {
                    Console.WriteLine("A vaga informada não existe!");
                    continue;
                }

                if (!vaga.Ocupada)
                {
                    Console.WriteLine("A vaga já está desocupada!");
                    continue;
                }

                var uso = vaga.FinalizarUso();
                var veiculo = Veiculos.FirstOrDefault(v => v.Placa == uso.PlacaVeiculo);
                veiculo?.Saiu();

                // Cálculo do preço
                DateTime dataHoraInicio = DateTime.Parse($"{uso.DataOcupacao} {uso.HoraOcupacao}");
                DateTime dataHoraFim = DateTime.Parse($"{uso.DataLiberacao} {uso.HoraLiberacao}");
                TimeSpan duracao = dataHoraFim - dataHoraInicio;
                decimal total = vaga.PrecoInicial + (vaga.PrecoHora * (decimal)duracao.TotalHours);

                Console.WriteLine($"A vaga {numeracao} foi desocupada.");
                Console.WriteLine($"Valor total: R$ {total:F2}");
                break;
            }
        }

        public void ListarVagas()
        {
            Console.WriteLine("Vagas disponíveis no estacionamento:");
            foreach (var vaga in Vagas)
            {
                Console.WriteLine($"- Numeração: {vaga.Numeracao} | Ocupada: {(vaga.Ocupada ? "Sim" : "Não")}");
            }
        }

        public void ListarVeiculos()
        {
            Console.WriteLine("Veículos no estacionamento:");
            foreach (var veiculo in Veiculos)
            {
                Console.WriteLine($"- Placa: {veiculo.Placa} | Estacionado: {(veiculo.Estacionado ? "Sim" : "Não")}");
            }
        }

        public void ListarHistoricoUso()
        {
            Console.WriteLine("Histórico de uso das vagas:");
            foreach (var vaga in Vagas)
            {
                Console.WriteLine($"- Vaga {vaga.Numeracao} | Usos: {vaga.Usos.Count}");
                foreach (var uso in vaga.Usos)
                {
                    Console.WriteLine($"  - Veículo: {uso.PlacaVeiculo} | Entrada: {uso.DataOcupacao} {uso.HoraOcupacao} | Saída: {uso.DataLiberacao} {uso.HoraLiberacao}");
                }
            }
        }
    }
}
