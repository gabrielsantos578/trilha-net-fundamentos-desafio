namespace DesafioFundamentos.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public bool Estacionado { get; private set; }

        public Veiculo(string placa)
        {
            this.Placa = placa;
            this.Estacionado = false;
        }

        public void Estacionou()
        {
            this.Estacionado = true;
        }

        public void Saiu()
        {
            this.Estacionado = false;
        }
    }
}
