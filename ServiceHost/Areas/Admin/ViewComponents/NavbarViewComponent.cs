using _01_QueryManagement.Contracts.Permissions;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Areas.Admin.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public PermissionQueryModel permissionQueryModels;
        private readonly IPermissionQueryModel _permissionQueryModel;
        public NavbarViewComponent(IPermissionQueryModel permissionQueryModel)
        {
            _permissionQueryModel = permissionQueryModel;
        }
        public IViewComponentResult Invoke()
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            return View(permissionQueryModels);
        }
    }
}