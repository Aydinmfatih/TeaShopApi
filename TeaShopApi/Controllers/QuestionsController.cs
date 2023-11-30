using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.DrinkDtos;
using TeaShopApi.DtoLayer.QuestionDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult QuestionList()
        {
            var values = _questionService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult QuestionList(CreateQuestionDto createQuestionDto)
        {
            Question question = new Question()
            {
                QuestionDetail = createQuestionDto.QuestionDetail,
                AnswerDetail = createQuestionDto.AnswerDetail
            };
            _questionService.TInsert(question);
            return Ok("Soru başarılı bir şekilde eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteQuestion(int id)
        {
            var values = _questionService.TGetById(id);
            _questionService.TDelete(values);
            return Ok("Soru başarılı bir şekilde silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {
            var values = _questionService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionDto updateQuestionDto)
        {
            Question question = new Question()
            {
                QuestionId=updateQuestionDto.QuestionId,
                AnswerDetail=updateQuestionDto.AnswerDetail,
                QuestionDetail=updateQuestionDto.QuestionDetail
            };
            _questionService.TUpdate(question);
            return Ok("Güncelleme işlemi yapıldı");
        }
    }
}
