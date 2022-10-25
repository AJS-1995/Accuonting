using _0_Framework.Domain;

namespace MoneyManagement.Domain.MoneyDomin
{
    public class Money : EntityBase<int>
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string ISO_Code { get; set; }
        public string Symbol { get; set; }
        public Money()
        {

        }
        public Money(string name, string country, string iSO_Code, string symbol, string slug, int userid)
        {
            Name = name;
            Country = country;
            ISO_Code = iSO_Code;
            Symbol = symbol;
            Slug = slug;
            User_Id = userid;
        }
        public void Edit(string name, string country, string iSO_Code, string symbol, string slug, int userid)
        {
            Name = name;
            Country = country;
            ISO_Code = iSO_Code;
            Symbol = symbol;
            Slug = slug;
            User_Id = userid;
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
