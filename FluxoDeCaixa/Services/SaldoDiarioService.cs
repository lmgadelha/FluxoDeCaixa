using FluxoDeCaixa.Models;

namespace FluxoDeCaixa.Services
{
    public class SaldoDiarioService
    {
        private readonly IFluxoDeCaixaRepository fluxoDeCaixaRepository;

        public SaldoDiarioService(IFluxoDeCaixaRepository fluxoDeCaixaRepository)
        {
            this.fluxoDeCaixaRepository = fluxoDeCaixaRepository;
        }

        public decimal ObterSaldoDiarioConsolidado()
        {
            decimal saldoDiarioConsolidado = fluxoDeCaixaRepository.ObterSaldoDiario();

            return saldoDiarioConsolidado;
        }
    }

}
