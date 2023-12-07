using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Context;

namespace TeaShopApi.DataAccessLayer.EntityFramework
{
    public class EfStatisticsDal : IStatisticsDal
    {
        private readonly TeaContext _context;

        public EfStatisticsDal(TeaContext context)
        {
            _context = context;
        }

        public decimal DrinkAveragePrice()
        {
           decimal value = _context.Drinks.Average(x => x.DrinkPrice);
            return value;
        }

        public int DrinkCount()
        {
            int value = _context.Drinks.Count();
            return value;
        }

        public string LastDrinkName()
        {
            string value = _context.Drinks.OrderByDescending(x=>x.DrinkId).Select(y=>y.DrinkName).Take(1).FirstOrDefault();
            return value;
        }

        public string MaxPriceDrink()
        {
            decimal price = _context.Drinks.Max(x => x.DrinkPrice);
            string value = _context.Drinks.Where(x => x.DrinkPrice == price).Select(y => y.DrinkName).FirstOrDefault();
            return value;
        }
    }
}
