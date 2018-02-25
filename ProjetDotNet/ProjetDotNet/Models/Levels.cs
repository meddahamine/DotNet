namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Levels
    {
        
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Niveau")]
        public string Title { get; set; }

        [Display(Name = "Cycle")]
        public Guid Cycle_Id { get; set; }

        public virtual Cycles Cycles { get; set; }

        public virtual ICollection<Pupils> Pupils { get; set; }

        public Levels()
        {
            Pupils = new HashSet<Pupils>();
        }
    }
}
