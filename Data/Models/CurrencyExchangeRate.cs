using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchangeCrud.Data.Models
{
    [Table("CurrencyExchangeRate", Schema = "Master")]
    public class CurrencyExchangeRate : DataModelBase
    {
        public int RefSourceCurrencyId { get; set; }
        [ForeignKey("RefSourceCurrencyId")]
        public CurrencyMaster? RefSourceCurrencyMaster { get; set; }

        public int RefTargetCurrencyId { get; set; }
        [ForeignKey("RefTargetCurrencyId")]
        public CurrencyMaster? RefTargetCurrencyMaster { get; set; }

        public DateTime ExchangeDate { get; set; }

        public double ExchangeRate { get; set; }
    }
}
