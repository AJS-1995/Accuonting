namespace _01_QueryManagement.Contracts.Users
{
    public class UserQueryModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Mobile { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string RolePersian { get; set; }
        public string ProfilePhoto { get; set; }
        public string SaveDate { get; set; }
        public bool Status { get; set; }
    }
}