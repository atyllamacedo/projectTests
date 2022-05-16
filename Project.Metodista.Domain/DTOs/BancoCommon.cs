namespace Project.Metodista.Domain.DTOs
{
    public class BancoCommon
    {
        public string MatriculaId { get; set; }
        public double Valor { get; set; }
        public string Nome { get; set; }
        public double Rendimento { get; set; }
        public double Taxa { get; set; }
        public int Meses { get; set; }

        public BancoCommon(string matriculaId, double valor, string nome, double rendimento, double taxa = 0, int meses = 0)
        {
            MatriculaId = matriculaId;
            Valor = valor;
            Nome = nome;
            Rendimento = rendimento;
            Taxa = taxa;
            Meses = meses;
        }
    }
}
