using _0_Framework.Domain;
using UserManagement.Application.Contracts.User;

namespace UserManagement.Domain.UserDomin
{
    public interface IUserRepository : IRepository<int, User>
    {
        User GetBy(string username);
        UserEdit GetDetails(int id);
        PermissionsCreate GetDetailsPer(string slug);
        List<UserViewModel> GetViewModel();
        List<UserViewModel> Search(UserSearchModel searchModel);
    }
}