using _0_Framework.Application;
using _01_QueryManagement.Contracts.Permissions;
using UserManagement.Application.Contracts.User;

namespace _01_QueryManagement.Query
{
    public class PermissionQuery : IPermissionQueryModel
    {
        private readonly IAuthHelper _authHelper;
        private readonly IUserApplication _userApplication;
        public PermissionQuery(IAuthHelper authHelper, IUserApplication userApplication)
        {
            _authHelper = authHelper;
            _userApplication = userApplication;
        }
        public PermissionQueryModel GetUsers()
        {
            var userslug = _userApplication.GetDetails(_authHelper.CurrentUserId())?.Slug;
            PermissionQueryModel cod = new PermissionQueryModel();
            if (userslug != null)
            {
                var create = _userApplication.GetDetailsPer(userslug);
                foreach (var item in create.MappedPermissions)
                {
                    if (item.Code == 10)
                    {
                        cod.AdminUsers = item.Code;
                    }
                    if (item.Code == 11)
                    {
                        cod.AddUsers = item.Code;
                    }
                    if (item.Code == 12)
                    {
                        cod.RemovedUsers = item.Code;
                    }
                    if (item.Code == 13)
                    {
                        cod.ActivedUsers = item.Code;
                    }
                    if (item.Code == 14)
                    {
                        cod.SearchUser = item.Code;
                    }
                    if (item.Code == 15)
                    {
                        cod.ListUsers = item.Code;
                    }
                    if (item.Code == 16)
                    {
                        cod.EditUser = item.Code;
                    }
                    if (item.Code == 17)
                    {
                        cod.ChangePasswordUser = item.Code;
                    }
                    if (item.Code == 18)
                    {
                        cod.RemoveUser = item.Code;
                    }
                    if (item.Code == 19)
                    {
                        cod.ActiveUser = item.Code;
                    }
                    if (item.Code == 20)
                    {
                        cod.LevelUser = item.Code;
                    }
                    if (item.Code == 21)
                    {
                        cod.SavedUser = item.Code;
                    }
                }
            }
            return cod;
        }
    }
}