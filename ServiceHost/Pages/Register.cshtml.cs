using _0_Framework.Application;
using CompanyManagement.Application.Contracts.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UserManagement.Application.Contracts.Role;
using UserManagement.Application.Contracts.User;

namespace ServiceHost.Pages
{
    public class RegisterModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SelectList Roles;

        public List<int> RoleIds { get; set; }

        public bool IsSuccedded { get; set; }
        private readonly ICompanyApplication _companyApplication;
        private readonly IUserApplication _userApplication;
        private readonly IRoleApplication _roleApplication;
        public RegisterModel(ICompanyApplication companyApplication, IUserApplication userApplication, IRoleApplication roleApplication)
        {
            _companyApplication = companyApplication;
            _userApplication = userApplication;
            _roleApplication = roleApplication;
        }

        public IActionResult OnGet()
        {
            var company = _companyApplication.GetViewModel();
            if (company.Count == 0)
            {
                return Redirect("./Company");
            }
            else
            {
                var user = _userApplication.GetViewModel();
                if (user.Count == 0)
                {
                    var role = _roleApplication.GetViewModel();
                    if (role.Count == 0)
                    {
                        var command = new RoleCreate() {};
                        _roleApplication.Create(command);
                    }
                    ViewData["Company"] = _companyApplication.GetViewModel().FirstOrDefault().Name;
                    ViewData["Logo"] = _companyApplication.GetViewModel().FirstOrDefault()?.Logo;
                    return Page();
                }
                else
                {
                    return Redirect("./Index");
                }
            }
        }
        public IActionResult OnPost(UserCreate command)
        {
            command.RoleId = _roleApplication.GetViewModel().FirstOrDefault().Id;
            RoleIds = new List<int>
            {
                10
            };
            command.Permissions = RoleIds;
            OperationResult result = _userApplication.Create(command);
            if (result.IsSuccedded == true)
            {
                Message = result.Message;
                IsSuccedded = result.IsSuccedded;
                return Page();
            }
            else
            {
                Message = result.Message;
                IsSuccedded = result.IsSuccedded;
                return Page();
            }
        }
    }
}