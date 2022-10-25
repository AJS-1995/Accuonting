namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public int Id { get; set; }
        public int RoleCod { get; set; }
        public string Role { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public List<int> Permissions { get; set; }

        public AuthViewModel()
        {
        }

        public AuthViewModel(int id, int rolecod, string fullname, string username, string mobile, List<int> permissions)
        {
            Id = id;
            RoleCod = rolecod;
            FullName = fullname;
            UserName = username;
            Mobile = mobile;
            Permissions = permissions;
        }
    }
}