using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N_K_School.Models
{
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }

        [Required(ErrorMessage = "Please Enter FirstName")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Please Enter MiddleName")]
        public String MiddleName { get; set; }

        [Required(ErrorMessage = "Please Enter LastName")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Please Enter DateOfBirth")]
        [DataType(DataType.Date)]
        public String Dob { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }

        [Required(ErrorMessage = "Please Enter Address")]
        public String Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter Phone")]
        public String Phone { get; set; }

        [Required(ErrorMessage = "Please Enter Gender")]
        public Genders Gender { get; set; }

        [Required(ErrorMessage = "Please Enter DateOfJoining")]
        [DataType(DataType.Date)]
        public String DateOfJoining { get; set; }

        [Required(ErrorMessage = "Please Enter Qualification")]
        public String Qualification { get; set; }


        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }
        public virtual ICollection<ClassTeacher> ClassTeacher { get; set; }

    }
}