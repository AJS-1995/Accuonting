namespace _0_Framework.Infrastructure
{
    public static class Roles
    {
        public const string Admin = "1";
        public const string Accountant = "2";
        public const string Viewer = "3";

        public static string GetRoleBy(int id)
        {
            switch (id)
            {
                case 1:
                    return "مدیر سیستم";
                case 2:
                    return "حسابدار";
                case 3:
                    return "بیننده";
                default:
                    return "";
            }
        }
    }
}