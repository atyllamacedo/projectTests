using System;
using System.Collections.Generic;

namespace Project.Metodista.Domain.DTOs
{
    public class OperacoesBancoDTO
    {
        public double Valor { get; set; }
        public List<Nullable<double>> ValorDeposito { get; set; }
        public string Messagem { get; set; }
        public string Montante { get; set; }
        public string Juros { get; set; }

        public OperacoesBancoDTO(double valor)
        {
            Valor = valor;
        }
        public OperacoesBancoDTO(List<double?> valorDepositolor)
        {
            ValorDeposito = valorDepositolor;
        }
        public OperacoesBancoDTO(double valor, string messagem, string montante, string juros) : this(valor)
        {
            Messagem = messagem;
            Montante = montante;
            Juros = juros;
        }
    }
}
