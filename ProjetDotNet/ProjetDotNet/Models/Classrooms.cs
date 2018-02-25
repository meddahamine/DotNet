namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Classrooms
    {
        
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Classe")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Utilisateur")]
        public Guid User_Id { get; set; }

        [Required]
        [Display(Name = "Année")]
        public Guid Year_Id { get; set; }

        [Required]
        [Display(Name = "Etablissement")]
        public Guid Establishment_Id { get; set; }

        public virtual Establishments Establishments { get; set; }

        public virtual Users Users { get; set; }

        public virtual Years Years { get; set; }
                
        public virtual ICollection<Evaluations> Evaluations { get; set; }

        public virtual ICollection<Pupils> Pupils { get; set; }

        public Classrooms()
        {
            Evaluations = new HashSet<Evaluations>();
            Pupils = new HashSet<Pupils>();
        }
    }
}
