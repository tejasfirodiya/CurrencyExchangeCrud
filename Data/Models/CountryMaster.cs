using System.ComponentModel.DataAnnotations.Schema;

namespace CurrencyExchangeCrud.Data.Models
{
    [Table("CountryMaster", Schema = "Master")]
    public class CountryMaster : DataModelExtras
    {
        public int RefCurrencyId { get; set; }
        [ForeignKey("RefCurrencyId")]
        public CurrencyMaster? RefCurrencyMaster { get; set; }
    }
}
