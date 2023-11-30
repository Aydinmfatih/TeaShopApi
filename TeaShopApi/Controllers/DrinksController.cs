using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.DrinkDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public IActionResult DrinkList()
        {
            var values = _drinkService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateDrink(CreateDrinkDto createDrinkDto)
        {
            Drink model = new Drink()
            {
                DrinkImageUrl = createDrinkDto.DrinkImageUrl,
                DrinkName = createDrinkDto.DrinkName,
                DrinkPrice = createDrinkDto.DrinkPrice
            };
            _drinkService.TInsert(model);
            return Ok("İçeceğiniz Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteDrink(int id)
        {
            var values = _drinkService.TGetById(id);
            _drinkService.TDelete(values);
            return Ok("İçecek silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetDrink(int id)
        {
            var values = _drinkService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateDrink(UpdateDrinkDto updateDrinkDto)
        {
            Drink drink = new Drink()
            {
                
                DrinkImageUrl = updateDrinkDto.DrinkImageUrl,
                DrinkName = updateDrinkDto.DrinkName,
                DrinkPrice = updateDrinkDto.DrinkPrice,
                DrinkId = updateDrinkDto.DrinkId
            };
            _drinkService.TUpdate(drink);
            return Ok("İçecek güncellendi");
        }

    }
}
