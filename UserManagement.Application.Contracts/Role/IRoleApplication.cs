using _0_Framework.Application;

namespace UserManagement.Application.Contracts.Role
{
    public interface IRoleApplication
    {
        OperationResult Create(RoleCreate command);
        OperationResult Edit(RoleEdit command);
        List<RoleViewModel> GetViewModel();
        RoleEdit GetDetails(int id);
        void Remove(int id);
        void Activate(int id);
        void On(int id);
        void Off(int id);
    }
}