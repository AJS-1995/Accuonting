using _0_Framework.Infrastructure;
using CompanyManagement.Application.Contracts.Company;
using CompanyManagement.Domain.CompanyDomin;

namespace CompanyMangement.Infrastructure.EFCore.Repository
{
    public class CompanyRepository : RepositoryBase<int, Company>, ICompanyRepository
    {
        private readonly CompanyContext _context;
        public CompanyRepository(CompanyContext context) : base(context)
        {
            _context = context;
        }
        public CompanyEdit GetDetails(int id)
        {
            var company = _context.Companys.Select(x => new CompanyEdit
            {
                Id = x.Id,
                Name = x.Name,
                Mobile = x.Mobile,
                Email = x.Email,
                Slug = x.Slug,
                MoneyId = x.MoneyId
            }).FirstOrDefault(x => x.Id == id);
            return company;
        }
        public List<CompanyViewModel> GetViewModel()
        {
            return _context.Companys.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Mobile = x.Mobile,
                Email = x.Email,
                Slug = x.Slug,
                Logo = x.Logo,
                SaveDate = x.SaveDate,
                MoneyId = x.MoneyId
            }).ToList();
        }
    }
}