using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.TestimonialDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialsController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTestimonail(CreateTestimonialDto createTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialComment=createTestimonialDto.TestimonialComment,
                TestimonialImageUrl=createTestimonialDto.TestimonialImageUrl,
                TestimonialName = createTestimonialDto.TestimonialName
            };
            _testimonialService.TInsert(testimonial);
            return Ok("Referans Eklendi");
        }
        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
           var values = _testimonialService.TGetById(id);
            _testimonialService.TDelete(values);
            return Ok("Refereans Silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetById(id);
            return Ok(values);
        }
        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialId = updateTestimonialDto.TestimonialId,
                TestimonialComment=updateTestimonialDto.TestimonialComment,
                TestimonialImageUrl=updateTestimonialDto.TestimonialImageUrl,
                TestimonialName=updateTestimonialDto.TestimonialName
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("Refereans Güncellenmiştir");
        }
    }
}
