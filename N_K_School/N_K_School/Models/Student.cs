using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace N_K_School.Models
{
    public enum Genders
    {
        [Display(Name = "Male")]
        Male = 0,
        [Display(Name = "Female")]
        Female = 1
    }
    public enum Standard
    {
        [Display(Name = "8th")]
        Standard_8th = 0,
        [Display(Name = "9th")]
        Standard_9th = 1,
        [Display(Name = "10th")]
        Standard_10th = 2

    }
    public enum ExamNo
    {
        [Display(Name = "First")]
        First_Exam = 1,
        [Display(Name = "Second")]
        Second_Exam = 2,
        [Display(Name = "Final")]
        Final_Exam = 3,
    }
    public class Student
    {
        [Key]
        public int StudentID {get;set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Enter FirstName")]
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

        [Required(ErrorMessage = "Please Enter Phone_Home")]
        [DataType(DataType.PhoneNumber)]
        public String Phone_Home { get; set; }

        [Required(ErrorMessage = "Please Enter Phone_Office")]
        [DataType(DataType.PhoneNumber)]
        public String Phone_Office { get; set; }

        [Required(ErrorMessage = "Please Enter EnteredStandard")]
        public Standard EnteredStandard { get; set; }

        [Required(ErrorMessage = "Please Enter CurrentStandard")]
        public Standard CurrentStandard { get; set; }

        [Required(ErrorMessage = "Please Enter Gender")]
        public Genders Gender { get; set; }

        [Required(ErrorMessage = "Please Enter DateOfAdmission")]
        [DataType(DataType.Date)]
        public String DateOfAdmission { get; set; }

    }
}