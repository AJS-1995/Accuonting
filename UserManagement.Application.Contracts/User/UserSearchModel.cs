namespace UserManagement.Application.Contracts.User
{
    public class UserSearchModel
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public int User_Id { get; set; }
    }
}