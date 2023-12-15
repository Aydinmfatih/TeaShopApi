using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using TeaShopApi.WebUI.Dtos.ContactDto;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultContactComponentParital : ViewComponent
    {


        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }



    }
}
