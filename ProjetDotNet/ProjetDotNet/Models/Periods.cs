namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Periods
    {
        
        public Guid Id { get; set; }

        [Display(Name = "Date debut")]
        [DataType(DataType.DateTime)]
        public DateTime Begin { get; set; }

        [Display(Name = "Date fin")]
        [DataType(DataType.DateTime)]
        public DateTime End { get; set; }

        [Display(Name = "Année")]
        public Guid Year_Id { get; set; }

        public virtual ICollection<Evaluations> Evaluations { get; set; }

        public virtual Years Years { get; set; }

        public Periods()
        {
            Evaluations = new HashSet<Evaluations>();
        }

    }
}
