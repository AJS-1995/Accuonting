using _0_Framework.Infrastructure;
using MoneyManagement.Application.Contracts.Money;
using MoneyManagement.Domain.MoneyDomin;
using UserManagement.Infrastructure.EFCore;

namespace MoneyMangement.Infrastructure.EFCore.Repository
{
    public class MoneyRepository : RepositoryBase<int, Money>, IMoneyRepository
    {
        private readonly MoneyContext _context;

        public MoneyRepository(MoneyContext context) : base(context)
        {
            _context = context;
        }

        public MoneyEdit GetDetails(int id)
        {
            var money = _context.Moneys.Select(x => new MoneyEdit
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Country = x.Country,
                ISO_Code = x.ISO_Code,
                Symbol = x.Symbol
            }).FirstOrDefault(x => x.Id == id);
            return money;
        }
        public List<MoneyViewModel> GetViewModel()
        {
            return _context.Moneys.Select(x => new MoneyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Country = x.Country,
                ISO_Code = x.ISO_Code,
                Symbol = x.Symbol,
                Active = x.Active,
                SaveDate = x.SaveDate,
                Status = x.Status,
                User_Id = x.User_Id,
                NameCountry = x.Name +" - "+ x.Country
            }).ToList();
        }
        public List<MoneyViewModel> Search(MoneySearchModel searchModel)
        {
            var query = _context.Moneys.Select(x => new MoneyViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                Country = x.Country,
                ISO_Code = x.ISO_Code,
                Symbol = x.Symbol,
                Active = x.Active,
                SaveDate = x.SaveDate,
                Status = x.Status,
                User_Id = x.User_Id
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Country))
                query = query.Where(x => x.Country.Contains(searchModel.Country));

            if (!string.IsNullOrWhiteSpace(searchModel.ISO_Code))
                query = query.Where(x => x.Country.Contains(searchModel.Country));

            if (!string.IsNullOrWhiteSpace(searchModel.Symbol))
                query = query.Where(x => x.Symbol.Contains(searchModel.Symbol));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}