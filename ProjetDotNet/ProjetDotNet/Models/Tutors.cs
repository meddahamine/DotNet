namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tutors
    {
        
        public Tutors()
        {
            Pupils = new HashSet<Pupils>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Prenom")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Adresse")]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Code postal")]
        public string PostCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ville")]
        public string Town { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Telephone")]
        public string Tel { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        [StringLength(1000)]
        [Display(Name = "Commentaire")]
        public string Comment { get; set; }

        
        public virtual ICollection<Pupils> Pupils { get; set; }
    }
}
