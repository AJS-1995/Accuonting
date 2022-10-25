using _01_QueryManagement.Contracts.Favicon;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class FaviconViewComponent : ViewComponent
    {
        private readonly IFaviconQueryModel _faviconQueryModel;
        public FaviconViewComponent(IFaviconQueryModel faviconQueryModel)
        {
            _faviconQueryModel = faviconQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            FaviconQueryModel favicon = new FaviconQueryModel();
            favicon = _faviconQueryModel.GetFavicons(); 
            return View(favicon);
        }
    }
}