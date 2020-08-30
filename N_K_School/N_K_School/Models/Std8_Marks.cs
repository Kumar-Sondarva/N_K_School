using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N_K_School.Models
{
    public class Std8_Marks
    {
        [Key]
        public int Std8Id { get; set; }
        public int StudentID { get; set; }

        public int English { get; set; }
        public int Maths { get; set; }
        public int Science { get; set; }
        public int SocialScience { get; set; }
        public int ExamNo { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }
}