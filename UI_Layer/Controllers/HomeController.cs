using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using Data_Layer;
using Microsoft.EntityFrameworkCore;
using UI_Layer;

namespace UI_Layer;

public class HomeController : Controller
{
    private readonly TradeEmulationService _tradeService;
    private readonly TradingDbContext _context;
    private static IServiceProvider? _rootServiceProvider;
    private static Timer? _timer;
    private static bool _timerStarted = false;

    public HomeController(TradeEmulationService tradeService, TradingDbContext context)
    {
        _tradeService = tradeService;
        _context = context;

        if (!_timerStarted && _rootServiceProvider != null)
        {
            _timerStarted = true;
            _timer = new Timer(async _ => await RunEmulationAsync(), null, TimeSpan.Zero, TimeSpan.FromSeconds(2));
        }
    }

    public static void SetRootServiceProvider(IServiceProvider serviceProvider)
    {
        _rootServiceProvider = serviceProvider;
    }

    private static async Task RunEmulationAsync()
    {
        if (_rootServiceProvider != null)
        {
            using var scope = _rootServiceProvider.CreateScope();
            var tradeService = scope.ServiceProvider.GetRequiredService<TradeEmulationService>();
            await tradeService.EmulateTradeAsync();
        }
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetCurrencyPairs()
    {
        var pairs = await _context.CurrencyPairs
            .Include(cp => cp.BaseCurrency)
            .Include(cp => cp.QuoteCurrency)
            .ToListAsync();

        var result = pairs.Select(cp => new CurrencyPairViewModel
        {
            BaseCurrency = cp.BaseCurrency.CurrencyAbbreviation,
            QuoteCurrency = cp.QuoteCurrency.CurrencyAbbreviation,
            MinValue = cp.MinValue,
            MaxValue = cp.MaxValue
        }).ToList();

        return Json(result);
    }
}
