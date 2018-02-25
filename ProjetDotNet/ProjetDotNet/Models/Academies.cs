namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Academies
    {
        
        public Academies()
        {
            Establishments = new HashSet<Establishments>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Academie")]
        public string Name { get; set; }

        
        public virtual ICollection<Establishments> Establishments { get; set; }
    }
}
