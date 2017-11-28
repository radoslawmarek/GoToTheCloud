using PICodeFirst.GoToTheCloud.App.Configurations;
using PICodeFirst.GoToTheCloud.App.TravelModel;
using PICodeFirst.GoToTheCloud.App.UserModel;
using PICodeFirst.GoToTheCloud.Infrastructure.Db.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace PICodeFirst.GoToTheCloud.Infrastructure.Db
{
    public class SqlTravelRepository : SqlRepositoryBase, ITravelRepository
    {
        public SqlTravelRepository(ConnectionStrings connectionStrings ) : base(connectionStrings)
        {
            
        }

        public IEnumerable<Travel> GetTravelList(User user)
        {
            var result = new List<Travel>();

            using (var connection = GetConnection())
            {
                var command = new SqlCommand();
                command.Connection = connection;

                if (user.IsApplicationAdministrator)
                {
                    command.CommandText = SqlTravelRepositoryQueries.GetTravelList;
                }
                else
                {
                    command.CommandText = SqlTravelRepositoryQueries.GetTravelListForUser;
                    command.Parameters.AddWithValue("user_id", user.Name);
                }

                using (var reader = command.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        result.Add(new Travel()
                        {
                            Description = reader.GetStringOrDefault("description"),
                            Start = reader.GetDateTimeOrDefault("start"),
                            Finish = reader.GetDateTimeOrDefault("finish"),
                            From = new Location()
                            {
                                Id = reader.GetGuidOrDefault("location_from_id"),
                                Name = reader.GetStringOrDefault("location_from_name")
                            },
                            To = new Location()
                            {
                                Id = reader.GetGuidOrDefault("location_to_id"),
                                Name = reader.GetStringOrDefault("location_to_name")
                            }
                        });
                    }
                }
            }

            return result;
        }
    }
}
