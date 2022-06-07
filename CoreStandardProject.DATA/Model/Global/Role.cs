using SSMDapperV2;
using Dapper;
using System.Data;

namespace CoreStandardProject.DATA.Model.Global
{
    public class Role : Repository
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Role() : base("NewTemplateDatabase")
        {

        }

        public Role GetUserRoleByUserId(int id)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            return GetSingle<Role>("GetUserRoleByUserId", parameters);
        }

        public Role GetUserRoleByUserName(string userName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("UserName", userName, DbType.String);

            return GetSingle<Role>("GetUserRoleByUserName", parameters);
        }

        public Role GetRoleByGroupNameAndAppName(string groupName, string appName)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("GroupName", groupName, DbType.String);
            parameters.Add("AppName", appName, DbType.String);

            return GetSingle<Role>("GetRoleByGroupNameAndAppName", parameters);
        }
    }
}
