using _0_Framework.Application;
using UserManagement.Application.Contracts.Role;
using UserManagement.Domain.RoleAgg;

namespace UserManagement.Application
{
    public class RoleApplication : IRoleApplication
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IAuthHelper _authHelper;
        public RoleApplication(IRoleRepository roleRepository, IAuthHelper authHelper)
        {
            _roleRepository = roleRepository;
            _authHelper = authHelper;
        }
        public void Activate(int id)
        {
            var result = _roleRepository.Get(id);
            result.Activate();
            _roleRepository.SaveChanges();
        }
        public OperationResult Create(RoleCreate command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.GetViewModel();
            if (role.Count == 0)
            {
                string sluga = "Admin".Slugify();
                var Admin = new Role("Admin", "مدیر سیستم", 1, sluga);
                _roleRepository.Create(Admin);
                _roleRepository.SaveChanges();

                string slugac = "Accountant".Slugify();
                var Accountant = new Role("Accountant", "حسابدار", 1, slugac);
                _roleRepository.Create(Accountant);
                _roleRepository.SaveChanges();

                string slugv = "Viewer".Slugify();
                var Viewer = new Role("Viewer", "بیننده", 1, slugv);
                _roleRepository.Create(Viewer);
                _roleRepository.SaveChanges();
            }
            else
            {
                if (_roleRepository.Exists(x => x.Name == command.Name))
                    return operation.Failed(ApplicationMessages.DuplicatedRecord);

                var user_id = _authHelper.CurrentUserId();
                string slug = command.Name.Slugify();
                var roles = new Role(command.Name, command.NamePersian, user_id, slug);
                _roleRepository.Create(roles);
                _roleRepository.SaveChanges();
            }
            return operation.Succedded();
        }
        public OperationResult Edit(RoleEdit command)
        {
            var operation = new OperationResult();
            var role = _roleRepository.Get(command.Id);
            if (role == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_roleRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var user_id = _authHelper.CurrentUserId();
            var slug = command.Name.Slugify();
            role.Edit(command.Name, command.NamePersian, user_id, slug);
            _roleRepository.SaveChanges();
            return operation.Succedded();
        }
        public RoleEdit GetDetails(int id)
        {
            return _roleRepository.GetDetails(id);
        }
        public List<RoleViewModel> GetViewModel()
        {
            return _roleRepository.GetViewModel();
        }
        public void Off(int id)
        {
            var result = _roleRepository.Get(id);
            result.Off();
            _roleRepository.SaveChanges();
        }
        public void On(int id)
        {
            var result = _roleRepository.Get(id);
            result.On();
            _roleRepository.SaveChanges();
        }
        public void Remove(int id)
        {
            var result = _roleRepository.Get(id);
            result.Remove();
            _roleRepository.SaveChanges();
        }
    }
}