using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeaShopApi.DataAccessLayer.Abstract
{
    public interface IStatisticsDal
    {
        int DrinkCount();
        decimal DrinkAveragePrice();
        string LastDrinkName();
        string MaxPriceDrink();
    }
}
