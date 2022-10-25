using _0_Framework.Domain;
using MoneyManagement.Application.Contracts.Money;

namespace MoneyManagement.Domain.MoneyDomin
{
    public interface IMoneyRepository : IRepository<int, Money>
    {
        MoneyEdit GetDetails(int id);
        List<MoneyViewModel> GetViewModel();
        List<MoneyViewModel> Search(MoneySearchModel searchModel);
    }
}
