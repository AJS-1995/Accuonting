using _01_QueryManagement.Contracts.Favicon;
using CompanyMangement.Infrastructure.EFCore;

namespace _01_QueryManagement.Query
{
    public class FaviconQuery : IFaviconQueryModel
    {
        private readonly CompanyContext _context;

        public FaviconQuery(CompanyContext context)
        {
            _context = context;
        }
        public FaviconQueryModel GetFavicons()
        {
            var user = _context.Companys.Select(x => new FaviconQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Logo = x.Logo
            }).FirstOrDefault();
            return user;
        }
    }
}