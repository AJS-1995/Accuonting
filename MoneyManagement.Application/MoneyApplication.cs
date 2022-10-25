using _0_Framework.Application;
using MoneyManagement.Application.Contracts.Money;
using MoneyManagement.Domain.MoneyDomin;

namespace MoneyManagement.Application
{
    public class MoneyApplication : IMoneyApplication
    {
        private readonly IMoneyRepository _moneyRepository;
        private readonly IAuthHelper _authHelper;
        public MoneyApplication(IMoneyRepository moneyRepository, IAuthHelper authHelper)
        {
            _moneyRepository = moneyRepository;
            _authHelper = authHelper;
        }
        public void Activate(int id)
        {
            var result = _moneyRepository.Get(id);
            result.Activate();
            _moneyRepository.SaveChanges();
        }
        public OperationResult Create(MoneyCreate command)
        {
            var operation = new OperationResult();
            if (_moneyRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var user_id = _authHelper.CurrentUserId();
            string slug = command.Name.Slugify();
            var money = new Money(command.Name, command.Country, command.ISO_Code, command.Symbol, slug, user_id);
            _moneyRepository.Create(money);
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }

        public void Delete(int id)
        {
            var result = _moneyRepository.Get(id);
            _moneyRepository.Delete(result);
            _moneyRepository.SaveChanges();
        }

        public OperationResult Edit(MoneyEdit command)
        {
            var operation = new OperationResult();
            var money = _moneyRepository.Get(command.Id);
            if (money == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_moneyRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var user_id = _authHelper.CurrentUserId();
            var slug = command.Name.Slugify();
            money.Edit(command.Name, command.Country, command.ISO_Code, command.Symbol, slug, user_id);
            _moneyRepository.SaveChanges();
            return operation.Succedded();
        }

        public MoneyEdit GetDetails(int id)
        {
            return _moneyRepository.GetDetails(id);
        }

        public List<MoneyViewModel> GetViewModel()
        {
            return _moneyRepository.GetViewModel();
        }

        public void Off(int id)
        {
            var result = _moneyRepository.Get(id);
            result.Off();
            _moneyRepository.SaveChanges();
        }

        public void On(int id)
        {
            var result = _moneyRepository.Get(id);
            result.On();
            _moneyRepository.SaveChanges();
        }

        public void Remove(int id)
        {
            var result = _moneyRepository.Get(id);
            result.Remove();
            _moneyRepository.SaveChanges();
        }

        public List<MoneyViewModel> Search(MoneySearchModel searchModel)
        {
            return _moneyRepository.Search(searchModel);
        }
    }
}