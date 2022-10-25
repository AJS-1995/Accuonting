using _0_Framework.Domain;
using CompanyManagement.Application.Contracts.Company;

namespace CompanyManagement.Domain.CompanyDomin
{
    public interface ICompanyRepository : IRepository<int, Company>
    {
        CompanyEdit GetDetails(int id);
        List<CompanyViewModel> GetViewModel();
    }
}
