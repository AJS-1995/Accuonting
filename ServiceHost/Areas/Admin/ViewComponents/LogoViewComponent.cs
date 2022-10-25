using _01_QueryManagement.Contracts.Favicon;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class LogoViewComponent : ViewComponent
    {
        private readonly IFaviconQueryModel _faviconQueryModel;
        public LogoViewComponent(IFaviconQueryModel faviconQueryModel)
        {
            _faviconQueryModel = faviconQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            FaviconQueryModel logo = new FaviconQueryModel();
            logo = _faviconQueryModel.GetFavicons();
            return View(logo);
        }
    }
}