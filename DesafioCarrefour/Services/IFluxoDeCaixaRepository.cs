namespace FluxoDeCaixa.Services
{
    public interface IFluxoDeCaixaRepository
    {
        decimal ObterSaldoDiario();
        void AtualizarSaldoDiario(decimal novoSaldoDiario);
    }

    public class FluxoDeCaixaRepository : IFluxoDeCaixaRepository
    {
        private decimal saldoDiario;

        public decimal ObterSaldoDiario()
        {
            return saldoDiario;
        }

        public void AtualizarSaldoDiario(decimal novoSaldoDiario)
        {
            saldoDiario = novoSaldoDiario;
        }
    }
}