namespace UserManagement.Application.Contracts.Role
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NamePersian { get; set; }
        public string SaveDate { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public string Slug { get; set; }
    }
}