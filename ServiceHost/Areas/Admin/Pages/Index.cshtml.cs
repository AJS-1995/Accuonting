using _01_QueryManagement;
using _01_QueryManagement.Contracts.Permissions;
using CompanyManagement.Application.Contracts.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoneyManagement.Application.Contracts.Money;
using UserManagement.Application.Contracts.User;
using UserManagement.Configuration.Permissions;

namespace ServiceHost.Areas.Admin.Pages
{
    public class IndexModel : PageModel
    {
        public CompanyEdit command;
        private readonly ICompanyApplication _companyApplication;
        private readonly IUserApplication _userApplication;
        private readonly IMoneyApplication _moneyApplication;
        public PermissionQueryModel permissionQueryModels;
        private readonly IPermissionQueryModel _permissionQueryModel;
        public IndexModel(IUserApplication userApplication, ICompanyApplication companyApplication, IMoneyApplication moneyApplication, IPermissionQueryModel permissionQueryModel)
        {
            _userApplication = userApplication;
            _companyApplication = companyApplication;
            _moneyApplication = moneyApplication;
            _permissionQueryModel = permissionQueryModel;
        }
        public void OnGet()
        {
        }
        public IActionResult OnGetLogout()
        {
            _userApplication.Logout();
            return RedirectToPage("/Index");
        }
        public IActionResult OnGetCompanyEdit()
        {
            permissionQueryModels = _permissionQueryModel.GetUsers();
            if (permissionQueryModels.ListUsers == UserPermissions.ListUsers)
            {
                var company = _companyApplication.GetViewModel().FirstOrDefault();
                ViewData["Email"] = "_@_._";
                command = new CompanyEdit()
                {
                    Name = company.Name,
                    Email = company.Email,
                    Id = company.Id,
                    Mobile = company.Mobile,
                    MoneyId = company.MoneyId,
                    Moneys = _moneyApplication.GetViewModel()
                };
                return Partial("Company/Index", command);
            }
            else
            {
                return Content("<script>window.location.href='/Index';</script>");
            }
        }
    }
}