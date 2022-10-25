namespace MoneyManagement.Application.Contracts.Money
{
    public class MoneyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameCountry { get; set; }
        public string Country { get; set; }
        public string ISO_Code { get; set; }
        public string Symbol { get; set; }
        public string SaveDate { get; set; }
        public int User_Id { get; set; }
        public string User_Name { get; set; }
        public bool Status { get; set; }
        public bool Active { get; set; }
        public string Slug { get; set; }
    }
}
