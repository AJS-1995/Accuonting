using _0_Framework.Application;
using CompanyManagement.Application.Contracts.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserManagement.Application.Contracts.User;

namespace ServiceHost.Pages
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public bool IsSuccedded { get; set; }    
        private readonly IUserApplication _userApplication;
        private readonly ICompanyApplication _companyApplication;
        private readonly IAuthHelper _authHelper;
        public IndexModel(IUserApplication accountApplication, IAuthHelper authHelper, ICompanyApplication companyApplication)
        {
            _userApplication = accountApplication;
            _authHelper = authHelper;
            _companyApplication = companyApplication;
        }
        public IActionResult OnGet(UserCreate command)
        {
            Message = null;
            var Authenticated = _authHelper.IsAuthenticated();
            if (Authenticated == true)
            {
                return Redirect("/Admin/Index");
            }
            else
            {
                var company = _companyApplication.GetViewModel();
                var user = _userApplication.GetViewModel();
                if (company.Count == 0 || user.Count == 0)
                {
                    return Redirect("./Company");
                }
                else
                {
                    ViewData["Company"] = _companyApplication.GetViewModel().FirstOrDefault()?.Name;
                    ViewData["Logo"] = _companyApplication.GetViewModel().FirstOrDefault()?.Logo;
                    return Page();
                }
            }
        }
        public IActionResult OnPostLogin(Login command)
        {
            OperationResult result = _userApplication.Login(command);
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
        public IActionResult OnGetLogout()
        {
            _userApplication.Logout();
            return RedirectToPage("/Index");
        }
    }
}