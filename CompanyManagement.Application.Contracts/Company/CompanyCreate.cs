using _0_Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace CompanyManagement.Application.Contracts.Company
{
    public class CompanyCreate
    {
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Name { get; set; }
        public IFormFile Logo { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Slug { get; set; }
        public string MoneyId { get; set; }
    }
}