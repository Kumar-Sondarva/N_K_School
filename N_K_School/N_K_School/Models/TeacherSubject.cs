using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N_K_School.Models
{
    public class TeacherSubject
    {
        [Key]
        [Column(Order = 1)]
        public int TeacherID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SubjectID { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual Subject Subject { get; set; }
    }
}