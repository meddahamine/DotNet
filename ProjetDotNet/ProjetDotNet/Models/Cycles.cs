namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Cycles
    {
        
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Cycle")]
        public string Title { get; set; }
        
        public virtual ICollection<Levels> Levels { get; set; }

        public Cycles()
        {
            Levels = new HashSet<Levels>();
        }
    }
}
