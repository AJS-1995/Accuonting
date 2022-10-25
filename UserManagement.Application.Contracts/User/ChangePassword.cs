namespace UserManagement.Application.Contracts.User
{
    public class ChangePassword
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public string SecurityCod { get; set; }
    }
}