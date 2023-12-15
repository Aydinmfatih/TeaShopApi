using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultStatisticsComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7059/api/Statistics/GetDrinkAveragePrice");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.v1 = jsonData1;


            var responseMessage2 = await client.GetAsync("https://localhost:7059/api/Statistics/GetDrinkCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.v2 = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7059/api/Statistics/GetLastDrinkName");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.v3 = jsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:7059/api/Statistics/GetMaxPriceDrink");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.v4 = jsonData4;
            return View();
        }
    }
}
