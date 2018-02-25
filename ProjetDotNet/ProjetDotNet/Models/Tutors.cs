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
        [DataType(DataType.PostalCode)]
        [Display(Name = "Code postal")]
        public string PostCode { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ville")]
        public string Town { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        [Display(Name = "Telephone")]
        public string Tel { get; set; }

        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        [StringLength(1000)]
        [Display(Name = "Commentaire")]
        public string Comment { get; set; }

        
        public virtual ICollection<Pupils> Pupils { get; set; }
    }
}
