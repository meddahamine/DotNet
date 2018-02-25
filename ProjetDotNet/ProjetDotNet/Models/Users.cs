namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        
        public Users()
        {
            Classrooms = new HashSet<Classrooms>();
            Establishments = new HashSet<Establishments>();
            Evaluations = new HashSet<Evaluations>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Pseudo")]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nom")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Prenom")]
        public string LastName { get; set; }

        [StringLength(50)]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        
        public virtual ICollection<Classrooms> Classrooms { get; set; }

        
        public virtual ICollection<Establishments> Establishments { get; set; }

        
        public virtual ICollection<Evaluations> Evaluations { get; set; }
    }
}
