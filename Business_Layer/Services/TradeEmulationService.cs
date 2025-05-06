using Data_Layer;
using Microsoft.EntityFrameworkCore;
using Business_Layer;

namespace BusinessLayer;

public class TradeEmulationService
{
    private readonly TradingDbContext _context;
    private readonly Random _random;

    public TradeEmulationService(TradingDbContext context)
    {
        _context = context;
        _random = new Random();
    }


    public async Task EmulateTradeAsync()
    {
        var currencyPairs = await _context.CurrencyPairs.ToListAsync();

        foreach (var pair in currencyPairs)
        {
            // Randomly adjust MinValue and MaxValue within the given range
            decimal minAdjustment = _random.NextDecimal(-0.05m, 0.05m);  // Adjust minValue by a small amount
            decimal maxAdjustment = _random.NextDecimal(-0.05m, 0.05m);  // Adjust maxValue by a small amount

            pair.MinValue = Math.Max(pair.MinValue + minAdjustment, 0);  // Ensure MinValue doesn't go negative
            pair.MaxValue = Math.Max(pair.MaxValue + maxAdjustment, pair.MinValue);  // Ensure MaxValue is greater than MinValue

            _context.CurrencyPairs.Update(pair);
        }

        await _context.SaveChangesAsync();
    }

}
