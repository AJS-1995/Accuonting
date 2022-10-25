namespace UserManagement.Domain.UserDomin
{
    public class Permission
    {
        public long Id { get; private set; }
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int UserId { get; private set; }
        public User User { get; private set; }
        public Permission(int code)
        {
            Code = code;
        }
        public Permission(int code, string name)
        {
            Code = code;
            Name = name;
        }
        public Permission(int code, int UserId)
        {
            Code = code;
            UserId = UserId;
        }
    }
}