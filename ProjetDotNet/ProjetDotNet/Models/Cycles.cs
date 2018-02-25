namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cycles
    {
        
        public Cycles()
        {
            Levels = new HashSet<Levels>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Cycle")]
        public string Title { get; set; }

        
        public virtual ICollection<Levels> Levels { get; set; }
    }
}
