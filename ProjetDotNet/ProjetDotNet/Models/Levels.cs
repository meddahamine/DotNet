namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Levels
    {
        
        public Levels()
        {
            Pupils = new HashSet<Pupils>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Niveau")]
        public string Title { get; set; }

        [Display(Name = "Cycle")]
        public Guid Cycle_Id { get; set; }

        public virtual Cycles Cycles { get; set; }

        
        public virtual ICollection<Pupils> Pupils { get; set; }
    }
}
