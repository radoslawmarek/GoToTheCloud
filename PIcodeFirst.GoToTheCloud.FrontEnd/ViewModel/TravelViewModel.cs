using PICodeFirst.GoToTheCloud.App.TravelModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PIcodeFirst.GoToTheCloud.FrontEnd.ViewModel
{
    public class TravelViewModel : IValidatableObject
    {
        public Guid Id { get; set; }

        [Display(Name ="Description")]
        public string Description { get; set; }

        [Display(Name ="Travel start date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }

        [Display(Name ="Travel finish date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Finish { get; set; }

        [Display(Name ="Travel from")]
        public Guid FromId { get; set; }

        [Display(Name = "Travel to")]
        public Guid ToId { get; set; }

        public IEnumerable<Location> Locations { get; set; }

        public IList<string> Errors { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Start > Finish)
            {
                yield return new ValidationResult($"Start date must by younger then finish date.", new string[] { nameof(Start), nameof(Finish) });

            }

            if (ToId == FromId)
            {
                yield return new ValidationResult($"Locations must be different.", new string[] { nameof(FromId), nameof(ToId) });
            }
        }
    }
}
