using _0_Framework.Application;

namespace CompanyManagement.Application.Contracts.Company
{
    public interface ICompanyApplication
    {
        OperationResult Create(CompanyCreate command);
        OperationResult Edit(CompanyEdit command);
        CompanyEdit GetDetails(int id);
        List<CompanyViewModel> GetViewModel();
    }
}
