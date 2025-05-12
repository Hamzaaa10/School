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
        public static class InstractorRouting
        {
            public const string Prefix = Rule + "Instractor";
            public const string List = Prefix + "/List";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete" + "/{id}";
            public const string Paginated = Prefix + "/Paginated";

        }
        public static class SubjectRouting
        {
            public const string Prefix = Rule + "Subject";
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
        public static class DepartmentSubjectRouting
        {
            public const string Prefix = Rule + "DepartmentSubject";
            public const string List = Rule + "Subjects" + "/Department" + "/{id}";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete";

        }
        public static class Ins_SubjectRouting
        {
            public const string Prefix = Rule + "Ins_Subject";
            public const string List = Rule + "Subjects" + "/Instractor" + "/{id}";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete";

        }

        public static class StudentSubjectRouting
        {
            public const string Prefix = Rule + "StudentSubject";
            public const string List = Rule + "Subjects" + "/Student" + "/{id}";
            public const string GetByID = Prefix + "/{id}";
            public const string Create = Prefix + "/Create";
            public const string Update = Prefix + "/Edit";
            public const string Delete = Prefix + "/Delete";

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
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
            public const string SendResetPasswordCode = Prefix + "/SendResetPasswordCode";



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
        public static class EmailRouting
        {
            public const string Prefix = Rule + "Email";
            public const string SendEmail = Prefix + "Send";
        }

    }
}
