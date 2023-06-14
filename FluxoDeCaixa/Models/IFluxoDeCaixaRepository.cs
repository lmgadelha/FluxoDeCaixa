using FluxoDeCaixa.Controllers;

namespace FluxoDeCaixa.Models
{
    public interface IFluxoDeCaixaRepository
    {
        decimal ObterSaldoDiario();
        void AtualizarSaldoDiario(decimal novoSaldoDiario);
        void RegistrarLancamento(TipoLancamento tipoLancamento, decimal valor);
    }

    public class FluxoDeCaixaRepository : IFluxoDeCaixaRepository
    {
        private static decimal saldoDiario;

        public decimal ObterSaldoDiario()
        {
            return saldoDiario;
        }

        public void AtualizarSaldoDiario(decimal novoSaldoDiario)
        {
            saldoDiario = novoSaldoDiario;
        }

        public void RegistrarLancamento(TipoLancamento tipoLancamento, decimal valor)
        {
            switch (tipoLancamento)
            {
                case TipoLancamento.Credito: saldoDiario += valor;
                    break;
                case TipoLancamento.Debito: saldoDiario -= valor;
                    break;
                default:
                    break;
            }
        }
    }
}