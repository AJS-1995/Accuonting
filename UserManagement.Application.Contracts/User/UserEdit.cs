using _0_Framework.Infrastructure;

namespace UserManagement.Application.Contracts.User
{
    public class UserEdit : UserCreate
    {
        public int Id { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }

        public UserEdit()
        {
            Permissions = new List<int>();
        }
    }
}