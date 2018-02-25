namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Evaluations
    {
        
        public Guid Id { get; set; }

        [Display(Name = "Classe")]
        public Guid Classroom_Id { get; set; }

        [Display(Name = "utilisateur")]
        public Guid User_Id { get; set; }

        [Display(Name = "Periode")]
        public Guid Period_Id { get; set; }

        [Display(Name = "Date Evaluation")]
        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

        [Display(Name = "Point total")]
        public int TotalPoint { get; set; }

        public virtual Classrooms Classrooms { get; set; }

        public virtual Periods Periods { get; set; }

        public virtual Users Users { get; set; }

        public virtual ICollection<Results> Results { get; set; }

        public Evaluations()
        {
            Results = new HashSet<Results>();
        }
    }
}
