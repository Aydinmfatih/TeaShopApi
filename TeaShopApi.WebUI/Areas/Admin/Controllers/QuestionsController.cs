using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShopApi.WebUI.Dtos.DrinkDtos;
using TeaShopApi.WebUI.Dtos.QuestionDtos;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class QuestionsController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public QuestionsController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7059/api/Questions");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultQuestionDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateQuestion()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateQuestion(CreateQuestionDto createQuestionDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createQuestionDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PostAsync("https://localhost:7059/api/Questions",content);
			if (responseMessage.IsSuccessStatusCode)
			{ 
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteQuestion(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:7059/api/Questions?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
					return RedirectToAction("Index");
            }
			return View();
        }

		[HttpGet]
		public async Task<IActionResult> UpdateQuestion(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7059/api/Questions/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateQuestionDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
        public async Task<IActionResult> UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateQuestionDto);
			StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
			var responseMessage = await client.PutAsync("https://localhost:7059/api/Questions/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();

        }
    }
}
