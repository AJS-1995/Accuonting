using _0_Framework.Application;
using _01_MarketFazliQuery;
using _01_QueryManagement.Contracts.Users;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly IUserQueryModel _userQueryModel;
        private readonly IAuthHelper _authHelper;
        public SidebarViewComponent(IAuthHelper authHelper, IUserQueryModel userQueryModel)
        {
            _authHelper = authHelper;
            _userQueryModel = userQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            var userid = _authHelper.CurrentUserInfo();
            var result = new SidebarModel
            {
                UsersQueryModel = _userQueryModel.GetUsers(userid.Id),
            };
            return View(result);
        }
    }
}