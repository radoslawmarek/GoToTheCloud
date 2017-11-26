using PICodeFirst.GoToTheCloud.App.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PICodeFirst.GoToTheCloud.App.TravelModel
{
    public interface ITravelRepository
    {
        IEnumerable<Travel> GetTravelList(User user);
    }
}
