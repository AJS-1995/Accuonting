using _0_Framework.Infrastructure;
using UserManagement.Application.Contracts.Role;
using UserManagement.Domain.RoleAgg;
using UserManagement.Infrastructure.EFCore;

namespace UserMangement.Infrastructure.EFCore.Repository
{
    public class RoleRepository : RepositoryBase<int, Role>, IRoleRepository
    {
        private readonly UserContext _context;

        public RoleRepository(UserContext context) : base(context)
        {
            _context = context;
        }

        public RoleEdit GetDetails(int id)
        {
            var role = _context.Roles.Select(x => new RoleEdit
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug,
                NamePersian = x.NamePersian,
            }).FirstOrDefault(x => x.Id == id);

            return role;
        }
        public List<RoleViewModel> GetViewModel()
        {
            return _context.Roles.Select(x => new RoleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                SaveDate = x.SaveDate,
                Slug = x.Slug,
                NamePersian = x.NamePersian,
            }).ToList();
        }
    }
}