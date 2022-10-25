using System.Collections.Generic;

namespace UserManagement.Application.Contracts.Role
{
    public class RoleCreate
    {
        public string Name { get; set; }
        public string NamePersian { get; set; }
        public string Slug { get; set; }
    }

}
