namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Years
    {
        
        public Guid Id { get; set; }

        [Display(Name = "Année")]
        [Required]
        public int Year { get; set; }

        public virtual ICollection<Classrooms> Classrooms { get; set; }

        public virtual ICollection<Periods> Periods { get; set; }

        public Years()
        {
            Classrooms = new HashSet<Classrooms>();
            Periods = new HashSet<Periods>();
        }
    }
}
