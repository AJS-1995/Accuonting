using _0_Framework.Application;

namespace MoneyManagement.Application.Contracts.Money
{
    public interface IMoneyApplication
    {
        OperationResult Create(MoneyCreate command);
        OperationResult Edit(MoneyEdit command);
        MoneyEdit GetDetails(int id);
        List<MoneyViewModel> GetViewModel();
        List<MoneyViewModel> Search(MoneySearchModel searchModel);
        void Remove(int id);
        void Activate(int id);
        void On(int id);
        void Off(int id);
        void Delete(int id);
    }
}