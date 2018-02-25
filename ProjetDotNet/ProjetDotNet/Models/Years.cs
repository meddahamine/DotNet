namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Years
    {
        
        public Years()
        {
            Classrooms = new HashSet<Classrooms>();
            Periods = new HashSet<Periods>();
        }

        public Guid Id { get; set; }

        [Display(Name = "Année")]
        public int Year { get; set; }

        
        public virtual ICollection<Classrooms> Classrooms { get; set; }

        
        public virtual ICollection<Periods> Periods { get; set; }
    }
}
