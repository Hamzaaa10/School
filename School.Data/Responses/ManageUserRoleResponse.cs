﻿namespace School.Data.Response
{
    public class ManageUserRoleResponse
    {
        public int UserId { get; set; }
        public List<UserRole> Roles { get; set; }

    }
    public class UserRole
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasRole { get; set; }
    }
}
