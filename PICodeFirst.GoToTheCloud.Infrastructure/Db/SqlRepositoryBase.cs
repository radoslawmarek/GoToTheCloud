using PICodeFirst.GoToTheCloud.App.Configurations;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PICodeFirst.GoToTheCloud.Infrastructure.Db
{
    public class SqlRepositoryBase
    {
        private readonly ConnectionStrings _connectionStrings;

        public SqlRepositoryBase(ConnectionStrings connectionStrings)
        {
            _connectionStrings = connectionStrings;
        }

        public SqlConnection GetConnection(bool open = true)
        {
            var connection = new SqlConnection(_connectionStrings.DefaultConnection);
            if (open)
            {
                connection.Open();
            }

            return connection;
        }
    }
}
