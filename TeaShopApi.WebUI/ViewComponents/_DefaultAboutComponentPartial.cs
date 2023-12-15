using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultAboutComponentPartial:ViewComponent
    {
        public async  Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
