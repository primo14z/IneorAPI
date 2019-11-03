using IneorBusiness.Enum;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace IneorBusiness.Infrastructure
{
    public class SqlConnectionDapper
    {


        private Dictionary<DatabaseEnum, string> _sqlConnectionStrings;

        public SqlConnectionDapper(Dictionary<DatabaseEnum, string> sqlConnectionStrings)
        {
            this._sqlConnectionStrings = sqlConnectionStrings;
        }

        public SqlConnection SQLConnection()
        {
            string connectionString = null;

            if (_sqlConnectionStrings.ContainsKey(DatabaseEnum.SqlConnection))
            {
                connectionString = _sqlConnectionStrings[DatabaseEnum.SqlConnection];
            }
            return new SqlConnection(connectionString);
        }
    }
}
