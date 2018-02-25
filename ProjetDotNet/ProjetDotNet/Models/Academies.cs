namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Academies
    {
        
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Academie")]
        public string Name { get; set; }

        public ICollection<Establishments> Establishments { get; set; }

        public Academies()
        {
            Establishments = new HashSet<Establishments>();
        }
    }
}
