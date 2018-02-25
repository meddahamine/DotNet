namespace ProjetDotNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Results
    {
        public Guid Id { get; set; }

        [Display(Name = "Evaluation")]
        public Guid Evaluation_Id { get; set; }

        [Display(Name = "Eleve")]
        public Guid Pupil_Id { get; set; }

        [Display(Name = "Note")]
        public double Note { get; set; }

        public virtual Evaluations Evaluations { get; set; }

        public virtual Pupils Pupils { get; set; }
    }
}
