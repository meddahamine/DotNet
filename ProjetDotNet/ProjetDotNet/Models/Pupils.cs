namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Pupils
    {
        
        public Pupils()
        {
            Results = new HashSet<Results>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nom")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Prenom")]
        public string LastName { get; set; }

        [Display(Name = "Sexe")]
        public short Sex { get; set; }

        [Display(Name = "Date de naissance")]
        public DateTime BirthdayDate { get; set; }

        [Display(Name = "State")]
        public short State { get; set; }

        [Display(Name = "Tuteur")]
        public Guid Tutor_Id { get; set; }

        [Display(Name = "Classe")]
        public Guid Classroom_Id { get; set; }

        [Display(Name = "Niveau")]
        public Guid Level_Id { get; set; }

        public virtual Classrooms Classrooms { get; set; }

        public virtual Levels Levels { get; set; }

        public virtual Tutors Tutors { get; set; }

        
        public virtual ICollection<Results> Results { get; set; }
    }
}
