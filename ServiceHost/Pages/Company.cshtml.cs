using _0_Framework.Application;
using CompanyManagement.Application.Contracts.Company;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoneyManagement.Application.Contracts.Money;

namespace ServiceHost.Pages
{
    public class CompanyModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public SelectList money;
        public bool IsSuccedded { get; set; }
        private readonly ICompanyApplication _companyApplication;
        private readonly IAuthHelper _authHelper;
        private readonly IMoneyApplication _moneyApplication;
        public CompanyModel(IAuthHelper authHelper, ICompanyApplication companyApplication, IMoneyApplication moneyApplication)
        {
            _authHelper = authHelper;
            _companyApplication = companyApplication;
            _moneyApplication = moneyApplication;
        }
        public IActionResult OnGet()
        {
            Response.Cookies.Delete(".AspNetCore.Cookies");
            var company = _companyApplication.GetViewModel();
            if (company.Count == 0)
            {
                ViewData["Email"] = "_@_._";
                money = new SelectList(_moneyApplication.GetViewModel(), "Id", "NameCountry");
                return Page();
            }
            else
            {
                return Redirect("./Register");
            }
        }
        public IActionResult OnPost(CompanyCreate command)
        {
            OperationResult result = _companyApplication.Create(command);
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