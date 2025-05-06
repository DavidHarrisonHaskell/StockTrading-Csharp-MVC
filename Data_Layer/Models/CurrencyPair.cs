using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data_Layer;

[Table("CurrencyPair")]
public partial class CurrencyPair
{
    [Key]
    public int Id { get; set; }

    public int BaseCurrencyId { get; set; }

    public int QuoteCurrencyId { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal MinValue { get; set; }

    [Column(TypeName = "decimal(18, 4)")]
    public decimal MaxValue { get; set; }

    [ForeignKey("BaseCurrencyId")]
    [InverseProperty("CurrencyPairBaseCurrencies")]
    public virtual Currency BaseCurrency { get; set; } = null!;

    [ForeignKey("QuoteCurrencyId")]
    [InverseProperty("CurrencyPairQuoteCurrencies")]
    public virtual Currency QuoteCurrency { get; set; } = null!;
}
