using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShopApi.BusinessLayer.Abstract;
using TeaShopApi.DtoLayer.ContactDtos;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {

        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public IActionResult SendMessage(SendMessageDto sendMessageDto)
        {
            Contact model = new Contact()
            {
                Email = sendMessageDto.Email,
                Name = sendMessageDto.Name, 
                Message = sendMessageDto.Message,
                Subject = sendMessageDto.Subject,   
            };
            _contactService.TInsert(model);
            return Ok("Mesajınız Gönderildi");
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();
            return Ok(values);
        }
    }
}
