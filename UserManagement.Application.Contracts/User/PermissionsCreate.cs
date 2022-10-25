using _0_Framework.Infrastructure;

namespace UserManagement.Application.Contracts.User
{
    public class PermissionsCreate
    {
        public List<int> Permissions { get; set; }
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Slug { get; set; }
        public List<PermissionDto> MappedPermissions { get; set; }

        public PermissionsCreate()
        {
            Permissions = new List<int>();
        }
    }
}
