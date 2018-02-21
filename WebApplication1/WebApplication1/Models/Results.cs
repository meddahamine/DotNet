namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Results
    {
        public Guid Id { get; set; }

        public Guid Evaluation_Id { get; set; }

        public Guid Pupil_Id { get; set; }

        public double Note { get; set; }

        public virtual Evaluations Evaluations { get; set; }

        public virtual Pupils Pupils { get; set; }
    }
}
