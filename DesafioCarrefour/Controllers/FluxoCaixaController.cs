namespace FluxoDeCaixa.Controllers
{
    using FluxoDeCaixa.Models;
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
            decimal saldoDiario = _fluxoDeCaixaRepository.ObterSaldoDiario();
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
                return BadRequest("Tipo de lançamento inválido.");
            }

            if (request.Valor <= 0)
            {
                return BadRequest("O valor do lançamento deve ser maior que zero.");
            }

            // Registra o lançamento no fluxo de caixa
            _fluxoDeCaixaRepository.RegistrarLancamento(request.TipoLancamento, request.Valor);

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