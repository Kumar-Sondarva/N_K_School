using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N_K_School.Models
{
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public String SubjectName { get; set; }

        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
    }
}