using _0_Framework.Application;

namespace UserManagement.Application.Contracts.User
{
    public interface IUserApplication
    {
        UserViewModel GetUserBy(int id);
        OperationResult Create(UserCreate command);
        OperationResult Edit(UserEdit command);
        OperationResult Edit(PermissionsCreate command);
        OperationResult ChangePassword(ChangePassword command);
        UserEdit GetDetails(int id);
        PermissionsCreate GetDetailsPer(string slug);
        void Delete(int id);
        List<UserViewModel> GetViewModel();
        List<UserViewModel> Search(UserSearchModel searchModel);
        OperationResult Login(Login command);
        void Logout();
        void Remove(int id);
        void Activate(int id);
        void On(int id);
        void Off(int id);
    }
}