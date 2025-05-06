using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer;

public static class RandomExtensions
{
    public static decimal NextDecimal(this Random random, decimal minValue, decimal maxValue)
    {
        double range = (double)(maxValue - minValue);
        return minValue + (decimal)(random.NextDouble() * range);
    }
}

