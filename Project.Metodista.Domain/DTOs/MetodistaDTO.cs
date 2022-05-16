using SQLite;

namespace Project.Metodista.Domain.DTOs
{
    [Table("tb_Metodista")]
    public class MetodistaDTO
    {
        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Matricula")]
        public string Matricula { get; set; }

        [Column("ValorConta")]
        public double ValorConta { get; set; }

        [Column("Rendimento")]
        public double Rendimento { get; set; }

        [Column("Aplicacao")]
        public double Aplicacao { get; set; }

    }
}
