using PICodeFirst.GoToTheCloud.App.Configurations;
using PICodeFirst.GoToTheCloud.App.TravelModel;
using PICodeFirst.GoToTheCloud.App.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PICodeFirst.GoToTheCloud.Infrastructure.Db
{
    public class SqlTravelRepository : ITravelRepository
    {
        private readonly ConnectionStrings _connectionStrings;

        public SqlTravelRepository(ConnectionStrings connectionStrings )
        {
            _connectionStrings = connectionStrings;
        }

        public IEnumerable<Travel> GetTravelList(User user)
        {
            var result = new List<Travel>();

            result.Add(new Travel()
            {
                Id = Guid.NewGuid(),
                Start = DateTime.Now.AddDays(-14),
                Finish = DateTime.Now.AddDays(-7),
                From = new Location() { Name = "Gdańsk" },
                To = new Location() {  Name = "Warszawa" }
            });

            result.Add(new Travel()
            {
                Id = Guid.NewGuid(),
                Start = DateTime.Now.AddDays(-14),
                Finish = DateTime.Now.AddDays(-7),
                From = new Location() { Name = "Gdańsk" },
                To = new Location() { Name = "Warszawa" }
            });

            result.Add(new Travel()
            {
                Id = Guid.NewGuid(),
                Start = DateTime.Now.AddDays(-14),
                Finish = DateTime.Now.AddDays(-7),
                From = new Location() { Name = "Gdańsk" },
                To = new Location() { Name = "Warszawa" }
            });

            return result;
        }
    }
}
