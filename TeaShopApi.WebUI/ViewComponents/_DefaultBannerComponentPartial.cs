using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultBannerComponentPartial:ViewComponent
    {
       public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
