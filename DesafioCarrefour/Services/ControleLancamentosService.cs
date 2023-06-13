using static FluxoDeCaixa.Models.Enums;

namespace FluxoDeCaixa.Services
{
    public class ControleLancamentosService
    {
        private readonly IFluxoDeCaixaRepository fluxoDeCaixaRepository;

        public ControleLancamentosService(IFluxoDeCaixaRepository fluxoDeCaixaRepository)
        {
            this.fluxoDeCaixaRepository = fluxoDeCaixaRepository;
        }

        public void RegistrarLancamento(TipoLancamento tipoLancamento, decimal valor)
        {
            // Validação do valor do lançamento
            if (valor <= 0)
            {
                throw new ArgumentException("O valor do lançamento deve ser maior que zero.");
            }

            // Recuperar o saldo diário atual
            decimal saldoDiario = fluxoDeCaixaRepository.ObterSaldoDiario();

            // Atualizar o saldo com base no tipo de lançamento
            if (tipoLancamento == TipoLancamento.Credito)
            {
                saldoDiario += valor;
            }
            else if (tipoLancamento == TipoLancamento.Debito)
            {
                saldoDiario -= valor;
            }

            // Salvar o novo saldo diário
            fluxoDeCaixaRepository.AtualizarSaldoDiario(saldoDiario);
        }
    }
}
