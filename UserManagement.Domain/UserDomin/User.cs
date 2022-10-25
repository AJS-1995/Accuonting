using _0_Framework.Domain;
using UserManagement.Domain.RoleAgg;

namespace UserManagement.Domain.UserDomin
{
    public class User : EntityBase<int>
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string SecurityCod { get; private set; }
        public int RoleId { get; private set; }
        public Role Role { get; private set; }
        public string ProfilePhoto { get; private set; }
        public List<Permission> Permissions { get; private set; }
        public User()
        {
        }
        public User(string fullname, string username, string password, string mobile, string securitycod, int roleId,
            string profilePhoto, List<Permission> permissions, int user_Id, string slug)
        {
            FullName = fullname;
            UserName = username;
            Password = password;
            Mobile = mobile;
            SecurityCod = securitycod;
            RoleId = roleId;
            ProfilePhoto = profilePhoto;
            Permissions = permissions;
            User_Id = user_Id;
            Slug = slug;
        }
        public void Edit(string fullname, string username, string mobile, int roleId, string profilePhoto, int user_Id, string slug)
        {
            FullName = fullname;
            UserName = username;
            Mobile = mobile;
            RoleId = roleId;
            if (!string.IsNullOrWhiteSpace(profilePhoto))
                ProfilePhoto = profilePhoto;
            User_Id = user_Id;
            Slug = slug;
        }
        public void Edit(List<Permission> permissions, int user_Id)
        {
            Permissions = permissions;
            User_Id = user_Id;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
        public void Remove()
        {
            Status = false;
        }
        public void Activate()
        {
            Status = true;
        }
        public void On()
        {
            Active = true;
        }
        public void Off()
        {
            Active = false;
        }
    }
}