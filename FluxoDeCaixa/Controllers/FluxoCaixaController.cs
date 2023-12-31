namespace FluxoDeCaixa.Controllers
{
    using FluxoDeCaixa.Models;
    using FluxoDeCaixa.Services;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class SaldosController : ControllerBase
    {
        private readonly IFluxoDeCaixaRepository _fluxoDeCaixaRepository;

        public SaldosController(IFluxoDeCaixaRepository fluxoDeCaixaRepository)
        {
            _fluxoDeCaixaRepository = fluxoDeCaixaRepository;
        }

        [HttpGet]
        public ActionResult<decimal> GetSaldoDiario()
        {
            var servicoSaldo = new SaldoDiarioService(_fluxoDeCaixaRepository);
            decimal saldoDiario = servicoSaldo.ObterSaldoDiarioConsolidado();
            return Ok(saldoDiario);
        }
    }

    [ApiController]
    [Route("api/[controller]")]
    public class LancamentosController : ControllerBase
    {
        private readonly IFluxoDeCaixaRepository _fluxoDeCaixaRepository;

        public LancamentosController(IFluxoDeCaixaRepository fluxoDeCaixaRepository)
        {
            _fluxoDeCaixaRepository = fluxoDeCaixaRepository;
        }

        [HttpPost]
        public IActionResult RegistrarLancamento(LancamentoRequest request)
        {
            if (request.TipoLancamento != TipoLancamento.Credito && request.TipoLancamento != TipoLancamento.Debito)
            {
                return BadRequest("Tipo de lan�amento inv�lido.");
            }

            if (request.Valor <= 0)
            {
                return BadRequest("O valor do lan�amento deve ser maior que zero.");
            }

            // Registra o lan�amento no fluxo de caixa
            var servicoLancamento = new ControleLancamentosService(_fluxoDeCaixaRepository);
            servicoLancamento.RegistrarLancamento(request.TipoLancamento, request.Valor);

            return Ok();
        }
    }

    public class LancamentoRequest
    {
        public TipoLancamento TipoLancamento { get; set; }
        public decimal Valor { get; set; }
    }

    public enum TipoLancamento
    {
        Credito,
        Debito
    }
}