using PICodeFirst.GoToTheCloud.App.TravelModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.ViewModel
{
    public class TravelViewModel
    {
        public Guid Id { get; set; }
        [Display(Name ="Description")]
        public string Description { get; set; }
        [Display(Name ="Travel start date")]
        public DateTime Start { get; set; }
        [Display(Name ="Travel finish date")]
        public DateTime Finish { get; set; }
        [Display(Name ="Travel from")]
        public Guid FromId { get; set; }
        [Display(Name = "Travel to")]
        public Guid ToId { get; set; }

        public IEnumerable<Location> Locations { get; set; }

    }
}
