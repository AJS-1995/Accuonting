namespace MoneyManagement.Application.Contracts.Money
{
    public class MoneyCreate
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string ISO_Code { get; set; }
        public string Symbol { get; set; }
        public string Slug { get; set; }
    }
}
