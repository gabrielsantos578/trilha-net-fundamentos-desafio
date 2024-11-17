using System;

namespace DesafioFundamentos.Models
{
    public class Uso
    {
        public string PlacaVeiculo { get; set; }
        public string DataOcupacao { get; private set; }
        public string HoraOcupacao { get; private set; }
        public string DataLiberacao { get; private set; }
        public string HoraLiberacao { get; private set; }

        public Uso(string placa)
        {
            this.PlacaVeiculo = placa;
            this.DataOcupacao = DateTime.Now.ToString("dd/MM/yyyy");
            this.HoraOcupacao = DateTime.Now.ToString("HH:mm:ss");
        }

        public void FinalizarUso()
        {
            this.DataLiberacao = DateTime.Now.ToString("dd/MM/yyyy");
            this.HoraLiberacao = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
