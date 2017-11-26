using System;
using System.Collections.Generic;
using System.Text;

namespace PICodeFirst.GoToTheCloud.App.TravelModel
{
    public class Travel
    {
        public Guid Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public Location From { get; set; }
        public Location To { get; set; }
    }
}
