using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N_K_School.Models
{
    public class ClassTeacher
    {
        [Key]
        public Standard Standards { get; set; }
        public int TeacherID { get; set; }

        public virtual Teacher Teacher { get; set; }
    }
}