using _0_Framework.Application;
using _0_Framework.Infrastructure;
using _01_QueryManagement.Contracts.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.NetworkInformation;
using UserManagement.Application.Contracts.User;
using UserManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Admin.Pages.Security.Users
{
    [Authorize(Roles = Roles.Admin)]
    public class LevelModel : PageModel
    {
        public PermissionsCreate Command;
        public List<SelectListItem> Permissions = new List<SelectListItem>();
        public PermissionQueryModel permissionQueryModels;

        private readonly IUserApplication _userApplication;
        private readonly IEnumerable<IPermissionExposer> _exposers;
        private readonly IPermissionQueryModel _permissionQueryModel;
        public LevelModel(IUserApplication userApplication, IEnumerable<IPermissionExposer> exposers, IPermissionQueryModel permissionQueryModel)
        {
            _userApplication = userApplication;
            _exposers = exposers;
            _permissionQueryModel = permissionQueryModel;
        }
        public IActionResult OnGet(string slug)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.LevelUser == UserPermissions.LevelUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                Command = _userApplication.GetDetailsPer(slug);
                foreach (var exposer in _exposers)
                {
                    var exposedPermissions = exposer.Expose();
                    foreach (var (key, value) in exposedPermissions)
                    {
                        var group = new SelectListGroup { Name = key };
                        foreach (var permission in value)
                        {
                            var item = new SelectListItem(permission.Name, permission.Code.ToString())
                            {
                                Group = group
                            };

                            if (Command.MappedPermissions.Any(x => x.Code == permission.Code))
                                item.Selected = true;

                            Permissions.Add(item);
                        }
                    }
                }
                return Page();
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPost(PermissionsCreate command)
        {
            var result = _userApplication.Edit(command);
            return RedirectToPage("Index");
        }
    }
}
