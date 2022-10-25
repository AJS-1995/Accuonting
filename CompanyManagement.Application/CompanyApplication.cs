using _0_Framework.Application;
using CompanyManagement.Application.Contracts.Company;
using CompanyManagement.Domain.CompanyDomin;

namespace CompanyManagement.Application
{
    public class CompanyApplication : ICompanyApplication
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IFileUploader _fileUploader;
        public CompanyApplication(ICompanyRepository companyRepository, IFileUploader fileUploader)
        {
            _companyRepository = companyRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CompanyCreate command)
        {
            var operation = new OperationResult();
            if (_companyRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            string slug = command.Name.Slugify();

            var logoPath = "Company";
            var logoname = slug;
            var picturePath = _fileUploader.Upload(command.Logo, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            if (command.Email == null)
            {
                command.Email = "_@_._";
            }

            var company = new Company(command.Name, picturePath, command.Mobile, command.Email, slug, command.MoneyId);
            _companyRepository.Create(company);
            _companyRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(CompanyEdit command)
        {
            var operation = new OperationResult();
            var company = _companyRepository.Get(command.Id);
            if (company == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_companyRepository.Exists(x =>
                (x.Name == command.Name) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            if (command.Logo != null || company.Logo != "")
            {
                string path = company.Logo;
                _fileUploader.Delete(path);
            }

            var logoPath = "Company";
            var logoname = command.Name.Slugify();
            var picturePath = _fileUploader.Upload(command.Logo, logoPath, logoname);
            if (picturePath == "no")
                return operation.Failed(ApplicationMessages.PhotoFormat);

            string slug = command.Name.Slugify();

            company.Edit(command.Name, picturePath, command.Mobile, command.Email, slug, command.MoneyId);
            _companyRepository.SaveChanges();
            return operation.Succedded();
        }
        public CompanyEdit GetDetails(int id)
        {
            return _companyRepository.GetDetails(id);
        }
        public List<CompanyViewModel> GetViewModel()
        {
            return _companyRepository.GetViewModel();
        }
    }
}