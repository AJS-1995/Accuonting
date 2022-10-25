using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using UserManagement.Application.Contracts.User;
using UserManagement.Domain.UserDomin;
using UserManagement.Infrastructure.EFCore;

namespace UserMangement.Infrastructure.EFCore.Repository
{
    public class UserRepository : RepositoryBase<int, User>, IUserRepository
    {
        private readonly UserContext _context;

        public UserRepository(UserContext context) : base(context)
        {
            _context = context;
        }

        public User GetBy(string username)
        {
            return _context.Users.FirstOrDefault(x => x.UserName == username);
        }

        public UserEdit GetDetails(int id)
        {
            var role = _context.Users.Select(x => new UserEdit
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                RoleId = x.RoleId,
                UserName = x.UserName,
                SecurityCod = x.SecurityCod,
                MappedPermissions = MapPermissions(x.Permissions),
                Slug = x.Slug
            }).AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
            }
            return role;
        }
        private static List<PermissionDto> MapPermissions(IEnumerable<Permission> permissions)
        {
            return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
        }

        public List<UserViewModel> GetViewModel()
        {
            return _context.Users.Select(x => new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                SecurityCod = x.SecurityCod,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RolePersian = x.Role.NamePersian,
                RoleId = x.RoleId,
                UserName = x.UserName,
                SaveDate = x.SaveDate,
                Active = x.Active,
                Status = x.Status,
                Slug = x.Slug,
                User_Id = x.User_Id,
            }).ToList();
        }

        public List<UserViewModel> Search(UserSearchModel searchModel)
        {
            var query = _context.Users.Include(x => x.Role).Select(x => new UserViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Mobile = x.Mobile,
                SecurityCod = x.SecurityCod,
                ProfilePhoto = x.ProfilePhoto,
                Role = x.Role.Name,
                RolePersian = x.Role.NamePersian,
                RoleId = x.RoleId,
                UserName = x.UserName,
                SaveDate = x.SaveDate,
                Active = x.Active,
                Status = x.Status,
                Slug = x.Slug
            });

            if (!string.IsNullOrWhiteSpace(searchModel.FullName))
                query = query.Where(x => x.FullName.Contains(searchModel.FullName));

            if (!string.IsNullOrWhiteSpace(searchModel.UserName))
                query = query.Where(x => x.UserName.Contains(searchModel.UserName));

            if (!string.IsNullOrWhiteSpace(searchModel.Mobile))
                query = query.Where(x => x.Mobile.Contains(searchModel.Mobile));

            if (searchModel.RoleId > 0)
                query = query.Where(x => x.RoleId == searchModel.RoleId);

            return query.OrderByDescending(x => x.Id).ToList();
        }

        public PermissionsCreate GetDetailsPer(string slug)
        {
            var role = _context.Users.Select(x => new PermissionsCreate
            {
                Id = x.Id,
                FullName = x.FullName,
                MappedPermissions = MapPermissions(x.Permissions),
                Slug = x.Slug
            }).AsNoTracking().FirstOrDefault(x => x.Slug == slug);
            role.Permissions = role.MappedPermissions.Select(x => x.Code).ToList();
            return role;
        }
    }
}