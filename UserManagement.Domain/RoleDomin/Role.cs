using _0_Framework.Domain;
using UserManagement.Domain.UserDomin;

namespace UserManagement.Domain.RoleAgg
{
    public class Role : EntityBase<int>
    {
        public string Name { get; set; }
        public int Cod { get; set; }
        public string NamePersian { get; set; }
        public List<User> Users { get; private set; }
        public Role()
        {
        }
        public Role(string name, string namepersian, int user_Id, string slug)
        {
            Name = name;
            Cod = 1;
            NamePersian = namepersian;
            Users = new List<User>();
            User_Id = user_Id;
            Slug = slug;
        }
        public void Edit(string name, string namepersian, int user_Id, string slug)
        {
            Name = name;
            NamePersian = namepersian;
            User_Id = user_Id;
            Slug = slug;
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