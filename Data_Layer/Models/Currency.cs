using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer;

[Table("Currency")]
[Index("CurrencyAbbreviation", Name = "UQ__Currency__039AE8529294A3D6", IsUnique = true)]
public partial class Currency
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string Country { get; set; } = null!;

    [StringLength(50)]
    public string CurrencyName { get; set; } = null!;

    [StringLength(10)]
    public string CurrencyAbbreviation { get; set; } = null!;

    [InverseProperty("BaseCurrency")]
    public virtual ICollection<CurrencyPair> CurrencyPairBaseCurrencies { get; set; } = new List<CurrencyPair>();

    [InverseProperty("QuoteCurrency")]
    public virtual ICollection<CurrencyPair> CurrencyPairQuoteCurrencies { get; set; } = new List<CurrencyPair>();
}
