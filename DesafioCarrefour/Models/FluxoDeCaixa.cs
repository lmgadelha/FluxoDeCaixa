using static FluxoDeCaixa.Models.Enums;

namespace FluxoDeCaixa.Models
{    public class FluxoDeCaixa
    {
        public decimal SaldoDiario { get; set; }

        public void RegistrarLancamento(TipoLancamento tipoLancamento, decimal valor)
        {
            if (tipoLancamento == TipoLancamento.Credito)
            {
                SaldoDiario += valor;
            }
            else if (tipoLancamento == TipoLancamento.Debito)
            {
                SaldoDiario -= valor;
            }
        }
    }
}
