using System.ComponentModel;

namespace FluxoDeCaixa.Models
{
    public class Enums
    {
        public enum TipoLancamento
        {
            [Description("Débito")]
            Debito = 1,
            [Description("Edit")]
            Credito = 2
        }
    }
}
