using _0_Framework.Application;

namespace CompanyManagement.Domain.CompanyDomin
{
    public class Company
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Logo { get; private set; }
        public string Mobile { get; private set; }
        public string Email { get; private set; }
        public string Slug { get; private set; }
        public string SaveDate { get; private set; }
        public string MoneyId { get; private set; }
        public Company()
        {
        }
        public Company(string name, string logo, string mobile, string email, string slug, string moneyId)
        {
            Name = name;
            Logo = logo;
            Mobile = mobile;
            Email = email;
            Slug = slug;
            SaveDate = DateTime.Now.ToFarsiFull();
            MoneyId = moneyId;
        }
        public void Edit(string name, string logo, string mobile, string email, string slug, string moneyId)
        {
            Name = name;
            Logo = logo;
            Mobile = mobile;
            Email = email;
            Slug = slug;
            MoneyId = moneyId;
        }
    }
}