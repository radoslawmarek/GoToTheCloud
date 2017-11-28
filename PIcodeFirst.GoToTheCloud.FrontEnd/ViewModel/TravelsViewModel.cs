using PICodeFirst.GoToTheCloud.App.TravelModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.ViewModel
{
    public class TravelsViewModel
    {
        private bool _isAuthenticated = false;
        private IList<Travel> _travelList = new List<Travel>();
        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
            set { _isAuthenticated = value; }
        }
        public IEnumerable<Travel> Travels
        {
            get { return _travelList; }
            set { _travelList = new List<Travel>(value);  }
        }

    }
}
