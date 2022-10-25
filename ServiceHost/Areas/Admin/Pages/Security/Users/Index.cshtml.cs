using _0_Framework.Application;
using _01_QueryManagement;
using _01_QueryManagement.Contracts.Permissions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement.Application.Contracts.Role;
using UserManagement.Application.Contracts.User;
using UserManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Admin.Pages.Security.Users
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public UserSearchModel SearchModel;
        public List<UserViewModel> users;
        public SelectList Roles;
        public SelectList Users;
        public PermissionQueryModel permissionQueryModels;
        private readonly IPermissionQueryModel _permissionQueryModel;
        private readonly IRoleApplication _roleApplication;
        private readonly IUserApplication _userApplication;
        private readonly IAuthHelper _AuthHelper;
        public IndexModel(IUserApplication accountApplication, IRoleApplication roleApplication, IPermissionQueryModel permissionQueryModel, IAuthHelper authHelper)
        {
            _roleApplication = roleApplication;
            _userApplication = accountApplication;
            _permissionQueryModel = permissionQueryModel;
            _AuthHelper = authHelper;
        }
        public IActionResult OnGet(UserSearchModel searchModel)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.ListUsers == UserPermissions.ListUsers || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                Roles = new SelectList(_roleApplication.GetViewModel(), "Id", "NamePersian");
                Users = new SelectList(_userApplication.GetViewModel(), "Id", "FullName");
                users = _userApplication.Search(searchModel).Where(x => x.Status == true && x.Active == true).ToList();
                permissionQueryModels = _permissionQueryModel.GetUsers();
                return Page();
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public void OnPost(UserSearchModel searchModel)
        {
            Roles = new SelectList(_roleApplication.GetViewModel(), "Id", "NamePersian");
            Users = new SelectList(_userApplication.GetViewModel(), "Id", "FullName");
            users = _userApplication.Search(searchModel).Where(x => x.Status == true && x.Active == true).ToList();
            permissionQueryModels = _permissionQueryModel.GetUsers();
        }
        public IActionResult OnGetCreate()
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.AddUsers == UserPermissions.AddUsers || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var command = new UserCreate
                {
                    Roles = _roleApplication.GetViewModel()
                };
                return Partial("./Create", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostCreate(UserCreate command)
        {
            var result = _userApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved()
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.RemovedUsers == UserPermissions.RemovedUsers || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new UserRemoved()
                {
                    UserRemoveds = _userApplication.GetViewModel().Where(x => x.Status == false).ToList()
                };
                return Partial("./Removed", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetActived()
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            var currentAccout = _AuthHelper.CurrentUserInfo();
            if (currentAccout.Id != currentAccout.Id || permissionQueryModels.ActivedUsers == UserPermissions.ActivedUsers || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new UserRemoved()
                {
                    UserRemoveds = _userApplication.GetViewModel().Where(x => x.Active == false).ToList()
                };
                return Partial("./Actived", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnGetEdit(int id)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            var currentAccout = _AuthHelper.CurrentUserInfo();
            if (currentAccout.Id == currentAccout.Id || permissionQueryModels.EditUser == UserPermissions.EditUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var account = _userApplication.GetDetails(id);
                account.Roles = _roleApplication.GetViewModel();
                return Partial("Edit", account);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostEdit(UserEdit command)
        {
            var result = _userApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetChangePassword(int id)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            var currentAccout = _AuthHelper.CurrentUserInfo();
            if (currentAccout.Id == currentAccout.Id || permissionQueryModels.ChangePasswordUser == UserPermissions.ChangePasswordUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var command = new ChangePassword { Id = id };
                return Partial("ChangePassword", command);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public JsonResult OnPostChangePassword(ChangePassword command)
        {
            var result = _userApplication.ChangePassword(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(int id)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            var currentAccout = _AuthHelper.CurrentUserInfo();
            if (currentAccout.Id != currentAccout.Id || permissionQueryModels.RemoveUser == UserPermissions.RemoveUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new Messages()
                {
                    Href = "Remove",
                    Icon = "Question.webp",
                    Id = id,
                    Message = "میخواهید کاربر مورد نظر را حذف کنید ؟"
                };
                return Partial("./Message", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostRemove(int id)
        {
            _userApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetOff(int id)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            var currentAccout = _AuthHelper.CurrentUserInfo();
            if (currentAccout.Id != currentAccout.Id || permissionQueryModels.ActiveUser == UserPermissions.ActiveUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new Messages()
                {
                    Href = "Off",
                    Icon = "Question.webp",
                    Id = id,
                    Message = "میخواهید کاربر مورد نظر را غبر فعال کنید ؟"
                };
                return Partial("./Message", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostOff(int id)
        {
            _userApplication.Off(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetOn(int id)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.ActiveUser == UserPermissions.ActiveUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new Messages()
                {
                    Href = "On",
                    Icon = "Question.webp",
                    Id = id,
                    Message = "میخواهید کاربر مورد نظر را فعال کنید ؟"
                };
                return Partial("./Message", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostOn(int id)
        {
            _userApplication.On(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetActivate(int id)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.RemoveUser == UserPermissions.RemoveUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new Messages()
                {
                    Href = "Activate",
                    Icon = "Question.webp",
                    Id = id,
                    Message = "میخواهید کاربر مورد نظر را بازیابی کنید ؟"
                };
                return Partial("./Message", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostActivate(int id)
        {
            _userApplication.Activate(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetDelete(int id)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.RemoveUser == UserPermissions.RemoveUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var commnd = new Messages()
                {
                    Href = "Delete",
                    Icon = "Question.webp",
                    Id = id,
                    Message = "میخواهید کاربر مورد نظر را کامل حذف کنید ؟"
                };
                return Partial("./Message", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
        public IActionResult OnPostDelete(int id)
        {
            _userApplication.Delete(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetSaved(int id)
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.SavedUser == UserPermissions.SavedUser || permissionQueryModels.AdminUsers == UserPermissions.AdminUsers)
            {
                var saved = _userApplication.GetViewModel().Where(x => x.Id == id).FirstOrDefault();

                var commnd = new UserViewModel()
                {
                    FullName = saved.FullName,
                    User_Name = _userApplication.GetViewModel().Where(x => x.Id == saved.User_Id).FirstOrDefault().FullName,
                    SaveDate = saved.SaveDate,
                };
                return Partial("./Saved", commnd);
            }
            else
            {
                return Redirect("/Index");
            }
        }
    }
}