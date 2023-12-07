using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Abstract;

namespace TeaShopApi.BusinessLayer.Concrete
{
    public class StatisticsManager : IStatisticsService
    {
        private readonly IStatisticsDal _statisticsDal;

        public StatisticsManager(IStatisticsDal statisticsDal)
        {
            _statisticsDal = statisticsDal;
        }

        public decimal TDrinkAveragePrice()
        {
           return _statisticsDal.DrinkAveragePrice();
        }

        public int TDrinkCount()
        {
            return _statisticsDal.DrinkCount();
        }

        public string TLastDrinkName()
        {
            return _statisticsDal.LastDrinkName();
        }

        public string TMaxPriceDrink()
        {
            return _statisticsDal.MaxPriceDrink();
        }
    }
}
