namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Periods
    {
        
        public Periods()
        {
            Evaluations = new HashSet<Evaluations>();
        }

        public Guid Id { get; set; }

        [Display(Name = "Date debut")]
        public DateTime Begin { get; set; }

        [Display(Name = "Date fin")]
        public DateTime End { get; set; }

        [Display(Name = "Année")]
        public Guid Year_Id { get; set; }

        
        public virtual ICollection<Evaluations> Evaluations { get; set; }

        public virtual Years Years { get; set; }
    }
}
