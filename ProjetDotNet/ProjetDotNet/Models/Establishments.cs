namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Establishments
    {
        
        public Guid Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Etablissement")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Code postal")]
        public string PostCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ville")]
        public string Town { get; set; }

        [Display(Name = "Utilisateur")]
        public Guid User_Id { get; set; }

        [Display(Name = "Academie")]
        public Guid Academie_Id { get; set; }

        public virtual Academies Academies { get; set; }

        public virtual ICollection<Classrooms> Classrooms { get; set; }

        public virtual Users Users { get; set; }

        public Establishments()
        {
            Classrooms = new HashSet<Classrooms>();
        }
    }
}
