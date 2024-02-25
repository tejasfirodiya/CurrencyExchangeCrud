using System.ComponentModel.DataAnnotations;

namespace CurrencyExchangeCrud.Data.Models
{
    public class DataModelExtras : DataModelBase
    {
        [Required]
        public string Code { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}
