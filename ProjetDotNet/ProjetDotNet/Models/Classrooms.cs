namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Classrooms
    {
        
        public Classrooms()
        {
            Evaluations = new HashSet<Evaluations>();
            Pupils = new HashSet<Pupils>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Classe")]
        public string Title { get; set; }

        [Display(Name = "Utilisateur")]
        public Guid User_Id { get; set; }

        [Display(Name = "Année")]
        public Guid Year_Id { get; set; }

        [Display(Name = "Etablissement")]
        public Guid Establishment_Id { get; set; }

        public virtual Establishments Establishments { get; set; }

        public virtual Users Users { get; set; }

        public virtual Years Years { get; set; }

        
        public virtual ICollection<Evaluations> Evaluations { get; set; }

        
        public virtual ICollection<Pupils> Pupils { get; set; }
    }
}
