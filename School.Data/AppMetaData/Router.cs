namespace School.Data.AppMetaData
{
    public static class Router
    {
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";




        public static class StudentRouting
        {
            public const string Prefix = Rule + "Student";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Paginated = Prefix + "/Paginated";

        }
        public static class DepartmentRouting
        {
            public const string Prefix = Rule + "Department";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Paginated = Prefix + "/Paginated";

        }
        public static class UserRouting
        {
            public const string Prefix = Rule + "User";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Paginated = Prefix + "/Paginated";
            public const string ChangePassword = Prefix + "/Change-Password";

        }
        public static class AuthenticationRouting
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/RefreshToken";
            public const string ValidateToken = Prefix + "/ValidateToken";


        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "Authorization";
            public const string Create = Prefix + "/Role" + "/Create";
            public const string Update = Prefix + "/Role" + "/Update";
            public const string Delete = Prefix + "/Role" + "/Delete" + "/{id}";
            public const string GetAll = Prefix + "/Role" + "/GetAll";
            public const string GetById = Prefix + "/Role" + "/GetById" + "/{id}";
            public const string ManageUserRole = Prefix + "/Role" + "/ManageUserRole" + "/{id}";
            public const string ManageUserClaims = Prefix + "/Claim" + "/ManageUserClaims" + "/{id}";
            public const string UpdateUserRoles = Prefix + "/Role" + "/UpdateUserRoles";
            public const string UpdateUserClaims = Prefix + "/Claim" + "/UpdateUserClaims";





        }

    }
}
