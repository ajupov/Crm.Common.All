namespace Crm.Common.All.Roles
{
    public static class Roles
    {
        public const string System = "System";

        public const string Development = "Development";

        public const string Administration = "Administration";

        public const string Support = "Support";

        public const string Account = "Account";

        public const string User = "User";

        public const string Products = "Products";

        public const string Customers = "Customers";

        public const string Orders = "Orders";

        public const string Tasks = "Tasks";

        public static string[] Privileged = { System, Development, Administration, Support };
    }
}
