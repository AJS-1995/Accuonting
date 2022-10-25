using _0_Framework.Domain;
using UserManagement.Application.Contracts.Role;

namespace UserManagement.Domain.RoleAgg
{
    public interface IRoleRepository : IRepository<int, Role>
    {
        RoleEdit GetDetails(int id);
        List<RoleViewModel> GetViewModel();
    }
}
