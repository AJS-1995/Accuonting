using MoneyManagement.Application.Contracts.Money;

namespace CompanyManagement.Application.Contracts.Company
{
    public class CompanyEdit : CompanyCreate
    {
        public int Id { get; set; }
        public List<MoneyViewModel> Moneys { get; set; }
    }
}
