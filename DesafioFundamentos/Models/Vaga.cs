namespace DesafioFundamentos.Models
{
    public class Vaga
    {
        public string Numeracao { get; set; }
        public decimal PrecoInicial { get; set; }
        public decimal PrecoHora { get; set; }
        public bool Ocupada { get; private set; } // Propriedade manipulada apenas pela classe
        public List<Uso> Usos { get; private set; } // Propriedade manipulada apenas pela classe

        public Vaga(string numeracao, decimal precoInicial, decimal precoHora)
        {
            this.Numeracao = numeracao;
            this.PrecoInicial = precoInicial;
            this.PrecoHora = precoHora;
            this.Ocupada = false;
            this.Usos = new List<Uso>();
        }

        // Adiciona um novo uso à vaga e marca como ocupada
        public void AdicionarUso(Uso uso)
        {
            this.Usos.Insert(0, uso);
            this.Ocupada = true;
        }

        // Finaliza o último uso e marca a vaga como desocupada
        public Uso FinalizarUso()
        {
            var uso = this.Usos[0];
            uso.FinalizarUso();
            this.Ocupada = false;

            return uso;
        }
    }
}
