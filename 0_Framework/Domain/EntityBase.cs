using _0_Framework.Application;

namespace _0_Framework.Domain
{
    public class EntityBase<T>
    {
        public T Id { get; set; }
        public string SaveDate { get; set; }
        public bool Status { get; set; }
        public bool Active { get; set; }
        public int User_Id { get; set; }
        public string Slug { get; set; }

        public EntityBase()
        {
            SaveDate = DateTime.Now.ToFarsiFull();
            Status = true;
            Active = true;
        }
    }
}